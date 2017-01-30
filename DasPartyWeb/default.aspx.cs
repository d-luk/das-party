using System;
using System.Web.UI;
using DasPartyPersistence.Models;

namespace DasPartyWeb
{
    public partial class Default : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            playlist.DataSource = Playlist.GetByHost("9b9e4883-3d06-462f-ae16-324968aab4f6").GetTracks();
            playlist.DataBind();
        }
    }
}