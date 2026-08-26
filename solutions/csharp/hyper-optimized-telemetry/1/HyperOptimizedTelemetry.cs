using System;
public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading) 
    {
        byte[] payload;
        byte prefix;
        var buffer = new byte[9];
        
        switch (reading)
        {
            
            case >= ushort.MinValue and <= ushort.MaxValue:
                prefix = 0x02; // 2
                payload = BitConverter.GetBytes((ushort)reading);
                break;
            case >= short.MinValue and <= short.MaxValue:
                prefix = 0xfe; // 254
                payload = BitConverter.GetBytes((short)reading);
                break;
        
            // 3. int Bereich
            case >= int.MinValue and <= int.MaxValue:
                prefix = 0xfc; // 252
                payload = BitConverter.GetBytes((int)reading);
                break;
        
            // 4. uint Bereich
            case >= uint.MinValue and <= uint.MaxValue:
                prefix = 0x04; // 4
                payload = BitConverter.GetBytes((uint)reading);
                break;
        
            // 5. long Fallback (für alles, was darüber/darunter liegt)
            default:
                prefix = 0xf8; // 248
                payload = BitConverter.GetBytes(reading);
                break;
        }
        buffer[0] = prefix;

        payload.CopyTo(buffer, 1);

        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        switch (buffer[0])
        {
            case 0xf8: // 248 (long)
                return BitConverter.ToInt64(buffer, 1);
        
            case 0xfc: // 252 (int)
                return BitConverter.ToInt32(buffer, 1);
        
            case 0xfe: // 254 (short)
                return BitConverter.ToInt16(buffer, 1);
        
            case 0x02: // 2 (ushort)
                return BitConverter.ToUInt16(buffer, 1);
        
            case 0x04: // 4 (uint)
                return BitConverter.ToUInt32(buffer, 1);
        
            default:
                return 0L;
        }
    }
}
