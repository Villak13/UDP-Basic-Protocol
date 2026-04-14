using System.Net;
using System.Net.Sockets;
namespace UDP_Basic_Protocol.PacketHandler {
    public sealed record class Message {
        public required String Msg { get; init; }
        public required IPEndPoint IP { get; init; }
    }
    public class UDPBasicHandler(int port = 19023) : IDisposable {
        public event EventHandler<Message> PacketHandled;
        public int Port { get; } = port;

        readonly UdpClient Client = new(port);
        bool disposed = false;

        public Task PacketListener() {
            ObjectDisposedException.ThrowIf(disposed, this);
            return Task.Run(async () => {
                while (!disposed) {
                    try {
                        var receive = await Client.ReceiveAsync();
                        string message = System.Text.Encoding.UTF8.GetString(receive.Buffer);
                        PacketHandled?.Invoke(this, new Message { Msg=message, IP=receive.RemoteEndPoint });
                    } catch (ObjectDisposedException) {
                        break;
                    }
                }
            });
        }
        public async Task SendPacket(string message, IPEndPoint iPEndPoint) {
            ObjectDisposedException.ThrowIf(disposed, this);
            var bytes = System.Text.Encoding.UTF8.GetBytes(message);
            await Client.SendAsync(bytes, iPEndPoint);
        }

        public void Dispose() {
            if (disposed) return;
            disposed = true;
            Client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
