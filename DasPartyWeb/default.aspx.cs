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
            
            playlist.DataSource = Playlist.Get("penis").GetTracks().OrderBy(track => track.Votes).Reverse();
            playlist.DataBind();
        }
    }
}