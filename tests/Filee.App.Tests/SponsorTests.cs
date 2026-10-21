// "Sponsor" opens a window with Avet Digital's ways to support Filee: the T-Bank donation page first, then Telegram and
// the website. No other links: the window is the same for every language.

using Avalonia.Headless.XUnit;
using Avalonia.Media;
using Filee.App.Services;
using Filee.App.Views;
using Filee.Core.Localization;

namespace Filee.App.Tests;

public class SponsorTests
{
    [AvaloniaTheory]
    [InlineData("ru")]
    [InlineData("en")]
    [InlineData("ko")]
    public void Donation_comes_first_and_every_way_is_avet_digital(string language)
    {
        var ways = SponsorLinks.For(language);

        Assert.Equal(SponsorLinks.DonateUrl, ways[0].Url);
        Assert.Equal([SponsorLinks.DonateUrl, SponsorLinks.TelegramUrl, SponsorLinks.WebsiteUrl], ways.Select(w => w.Url));
        Assert.All(ways, w => Assert.Matches(@"^https://(t\.tb\.ru|t\.me/avetdigital|avetdigital\.ru)", w.Url));
    }

    [AvaloniaTheory]
    [InlineData("ru")]
    [InlineData("en")]
    [InlineData("zh-CN")]
    public void Every_way_has_its_logo_and_note(string language)
    {
        TestServices.EnsureInitialized(language);
        var window = SponsorWindow.Create(AppHost.Get<ILocalizer>());

        var ways = Assert.IsAssignableFrom<IEnumerable<SponsorWay>>(window.Ways.ItemsSource).ToList();
        Assert.Equal(3, ways.Count);
        Assert.All(ways, w =>
        {
            Assert.IsAssignableFrom<Geometry>(w.Icon);
            Assert.False(string.IsNullOrWhiteSpace(w.Note));
            Assert.DoesNotContain("sponsor.note.", w.Note);
        });
    }
}
