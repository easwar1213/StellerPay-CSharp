          // Automatically generated by xdrgen 
          // DO NOT EDIT or your changes may be overwritten

          namespace Stellar.Generated
{


// === xdr source ============================================================
//  union InflationResult switch (InflationResultCode code)
//  {
//  case INFLATION_SUCCESS:
//      InflationPayout payouts<>;
//  default:
//      void;
//  };
//  ===========================================================================
public class InflationResult {
  public InflationResult () {}
  public InflationResultCode Discriminant { get; set; } = new InflationResultCode();
  public InflationPayout[] Payouts { get; set; } = default(InflationPayout[]);
  public static void Encode(IByteWriter stream, InflationResult encodedInflationResult) {
  XdrEncoding.EncodeInt32((int)encodedInflationResult.Discriminant.InnerValue, stream);
  switch (encodedInflationResult.Discriminant.InnerValue) {
  case InflationResultCode.InflationResultCodeEnum.INFLATION_SUCCESS:
  int payoutssize = encodedInflationResult.Payouts.Length;
  XdrEncoding.EncodeInt32(payoutssize, stream);
  for (int i = 0; i < payoutssize; i++) {
    InflationPayout.Encode(stream, encodedInflationResult.Payouts[i]);
  }
  break;
  default:
  break;
  }
  }
  public static InflationResult Decode(IByteReader stream) {
    InflationResult decodedInflationResult = new InflationResult();
  decodedInflationResult.Discriminant = InflationResultCode.Decode(stream);
  switch (decodedInflationResult.Discriminant.InnerValue) {
  case InflationResultCode.InflationResultCodeEnum.INFLATION_SUCCESS:
  int payoutssize = XdrEncoding.DecodeInt32(stream);
  decodedInflationResult.Payouts = new InflationPayout[payoutssize];
  for (int i = 0; i < payoutssize; i++) {
    decodedInflationResult.Payouts[i] = InflationPayout.Decode(stream);
  }
  break;
  default:
  break;
  }
    return decodedInflationResult;
  }
}
}