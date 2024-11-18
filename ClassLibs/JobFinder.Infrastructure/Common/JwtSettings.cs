namespace JobFinder.Infrastructure;

public static class JwtSettings
{
  public static string SecretKey => "myjwtsecretkeytoencodeanddecodethetokens";
  public static string Issuer => "issuer.example";
}
