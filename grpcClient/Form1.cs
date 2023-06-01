using Grpc.Net.Client;

namespace grpcClient;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }


    private void sendBtn_Click(object sender, EventArgs e)
    {
        string name = TbName.Text;
        string channelLink = TbChannel.Text;
        if (string.IsNullOrEmpty(channelLink) || string.IsNullOrEmpty(name))
        {
            MessageBox.Show("Invalid values.", "Invalid Values", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }
        try
        {
            using var channel = GrpcChannel.ForAddress(TbChannel.Text);
            var client = new Greeter.GreeterClient(channel);
            HelloReply response = client.SayHello(new HelloRequest { Name = name });
            MessageBox.Show(response.Message);
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void groupBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.KeyCode == Keys.Enter || e.KeyValue == (char)Keys.Return)
        {
            sendBtn_Click(default!, default!);
        }
    }
}
