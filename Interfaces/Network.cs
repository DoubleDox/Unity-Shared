public interface IStateStreamer
{
    void OnSend(byte[] buffer, ref int offset);
    
    void OnReceive(byte[] buffer, ref int offset);
}