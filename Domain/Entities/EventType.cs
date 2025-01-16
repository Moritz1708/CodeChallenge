namespace Domain.Entities
{
  [Flags]
  public enum EventType
  {
    [Display(Name = "OnSite")]
    OnSite = 1,

    [Display(Name = "Online")]
    Online = 2,

    [Display(Name = "Hybrid")]
    Hybrid = OnSite | Online
  }
}