using System;
using System.Linq;
using System.Web.UI;
using DasPartyPersistence.Models;

namespace DasPartyWeb
{
    public partial class Default : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            playlist.Text = Playlist.Get("penis").GetTracks().OrderBy(track => track.Votes).Reverse()
                                .Aggregate("<ol>", (current, track)
                                    => current + "<li>" + track.Artist + " - " + track.Name
                                       + " [" + track.Votes + " votes]</li>") + "</ol>";
        }
    }
}