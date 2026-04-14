using System.Net;
using System.Collections.ObjectModel;
using UDP_Basic_Protocol.PacketHandler;

namespace UDP_Basic_Protocol {
    public partial class MainPage : ContentPage {
        readonly string separator = "234506234509";
        readonly UDPBasicHandler packetHandler = new(8088);
        readonly ObservableCollection<MessageDisplay> messages = [];
        class MessageDisplay {
            public string IP { get; set; }
            public string Username { get; set; }
            public string Text { get; set; }
            public bool ShowingIP { get; set; }
            public string DisplayText => $"[{(ShowingIP ? IP : Username)}]: {Text}";
        }
        public MainPage() {
            InitializeComponent();
            MessagesLayout.ItemsSource = messages;
            packetHandler.PacketHandled += onPacketHandled;

            packetHandler.PacketListener();
        }
        public void onPacketHandled(object? sender, Message message) {
            MainThread.BeginInvokeOnMainThread(() => {
                var parts = message.Msg.Split(separator);
                if (parts.Length < 2) return;

                string username = parts[0];
                string text = parts[1];

                messages.Add(new MessageDisplay {
                    IP = message.IP.ToString(),
                    Username = username,
                    Text = text,
                    ShowingIP = false
                });
            });
        }

        private void MessagesLayout_SelectionChanged(object? sender, SelectionChangedEventArgs e) {
            if (e.CurrentSelection.Count == 0 || e.CurrentSelection[0] is not MessageDisplay data) return;
            data.ShowingIP = !data.ShowingIP;
            var index = messages.IndexOf(data);
            if (index >= 0) {
                messages[index] = data;
            }

            if (sender is CollectionView collectionView) {
                collectionView.SelectedItem = null;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(Iphost.Text)) return;

            if (!IPEndPoint.TryParse(Iphost.Text, out var iphost) || iphost.Port <= 0) {
                await DisplayAlertAsync("Alert", "Enter endpoint as IP:PORT (port 1-65535).", "OK");
                return;
            }
            Console.WriteLine(iphost.ToString());
            await packetHandler.SendPacket(Username.Text + separator + WritedMessage.Text, iphost);
        }
    }
}
