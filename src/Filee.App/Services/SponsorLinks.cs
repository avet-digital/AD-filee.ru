// Where "Sponsor" can lead: the sidebar button and the About page open a window with Avet Digital's ways to support
// the program and to reach the company (AD-Brand/brand.json: support, contacts).

namespace Filee.App.Services;

/// <summary>One way to support Filee.</summary>
/// <param name="Id">Also the suffix of its description string, <c>sponsor.note.{Id}</c>.</param>
/// <param name="Icon">Key of the logo geometry (Styles/*.axaml).</param>
/// <param name="Color">Colour behind the white logo.</param>
public sealed record SponsorLink(string Id, string Name, string Url, string Icon, string Color);

public static class SponsorLinks
{
    /// <summary>Avet Digital's donation page (T-Bank).</summary>
    public const string DonateUrl = "https://t.tb.ru/pm_short/3CFjjbcH8x0";

    public const string TelegramUrl = "https://t.me/avetdigital";
    public const string WebsiteUrl = "https://avetdigital.ru/";

    private static readonly SponsorLink Donate = new("tbank", "Т-Банк", DonateUrl, "Icon.Heart", "#3B76CC");
    private static readonly SponsorLink Telegram = new("telegram", "Telegram", TelegramUrl, "Icon.Link", "#2F67BE");
    private static readonly SponsorLink Website = new("website", "avetdigital.ru", WebsiteUrl, "Icon.Home", "#4A86DA");

    /// <summary>Every way, in the same order for every language.</summary>
    public static IReadOnlyList<SponsorLink> For(string language) => [Donate, Telegram, Website];
}
