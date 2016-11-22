<%@ Page Title="Auth" Language="C#" MasterPageFile="_Layout.master" %>

<asp:Content runat="server" ID="Styles" ContentPlaceHolderID="Styles">
    <script>
(function() {
  var hash = {};
  window.location.hash.replace(/^#\/?/, '').split('&').forEach(function(kv) {
    var spl = kv.indexOf('=');
    if (spl != -1) {
      hash[kv.substring(0, spl)] = decodeURIComponent(kv.substring(spl+1));
    }
  });
  console.log('initial hash', hash);
  if (hash.access_token) {
    window.opener.postMessage(JSON.stringify({
      type:'access_token',
      access_token: hash.access_token,
      expires_in: hash.expires_in || 0
    }), 'http://das.party');
    window.close();
    }
})();
</script>
</asp:Content>

<asp:Content runat="server" ID="Content" ContentPlaceHolderID="Content">
    <h1>Hello</h1>
</asp:Content>

<asp:Content runat="server" ID="Scripts" ContentPlaceHolderID="Scripts"></asp:Content>
