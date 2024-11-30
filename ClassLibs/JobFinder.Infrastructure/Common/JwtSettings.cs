namespace JobFinder.Infrastructure;

public static class JwtSettings
{
  public static string UserSecretKey => "usermyjwtsecretkeytoencodeanddecodethetokens";
  public static string UserIssuer => "userissuer.example";

  public static string EmployerSecretKey => "employermyjwtsecretkeytoencodeanddecodethetokens";
  public static string EmployerIssuer => "employerissuer.example";
}
