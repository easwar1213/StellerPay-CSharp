          // Automatically generated by xdrgen 
          // DO NOT EDIT or your changes may be overwritten

          namespace Stellar.Generated
{


// === xdr source ============================================================
//  enum IPAddrType
//  {
//      IPv4 = 0,
//      IPv6 = 1
//  };
//  ===========================================================================
public class IPAddrType {
  public enum IPAddrTypeEnum
  {
  IPv4 = 0,
  IPv6 = 1,
  }

  public IPAddrTypeEnum InnerValue { get; set; } = default(IPAddrTypeEnum);

  public static IPAddrType Create(IPAddrTypeEnum v)
  {
    return new IPAddrType {
      InnerValue = v
    };
  }

  public static IPAddrType Decode(IByteReader stream) {
    int value = XdrEncoding.DecodeInt32(stream);
    switch (value) {
      case 0: return Create(IPAddrTypeEnum.IPv4);
      case 1: return Create(IPAddrTypeEnum.IPv6);
			default:
			  throw new System.Exception("Unknown enum value: " + value);
		  }
		}

		public static void Encode(IByteWriter stream, IPAddrType value) {
		  XdrEncoding.EncodeInt32((int)value.InnerValue, stream);
		}
}
}
