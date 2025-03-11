using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Business;
using System.Net;
using Microsoft.Ajax.Utilities;


namespace My_Pokedex
{
    public partial class ListOfPokemons : System.Web.UI.Page
    {
        public List<Pokemon> Pokemons { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
             {
                Pokemons = Session["FilteredList"] != null ?((List<Pokemon>) Session["FilteredList"]) : null;

                if((Pokemons is List<Pokemon>) && (Pokemons.Count > 0))
                {
                    ToAssignPictureToPokemons(Pokemons);
                }

                if (Pokemons is List<Pokemon>)
                {
                    Dgv_Pokemons.DataSource = Pokemons;
                    Dgv_Pokemons.DataBind();
                }
             
            }
        }

       

        protected void Dgv_Pokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = Dgv_Pokemons.SelectedDataKey.Value != null ? Dgv_Pokemons.SelectedDataKey.Value.ToString() : "";

            if (!(string.IsNullOrEmpty(Id)))
            {
                Response.Redirect("PokemonDetail.aspx?Id=" + Id);
            }

        }

        protected void Dgv_Pokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Session["ListOfPokemons"] != null)
            {
                Dgv_Pokemons.DataSource = Session["ListOfPokemons"];
                Dgv_Pokemons.PageIndex = e.NewPageIndex;
                Dgv_Pokemons.DataBind();
            }
        }

        private void ToAssignPictureToPokemons(List<Pokemon>AuxPokemonList)
        {
            string DefaultImage = "https://imgs.search.brave.com/k8au3W5lzEHwHuZTUDauZnE0D5rjuEP2KE8Qbh1lOio/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9jZG4w/Lmljb25maW5kZXIu/Y29tL2RhdGEvaWNv/bnMvaW50ZXJhY3Rp/b24tNS83MC9waWN0/dXJlX19nYWxsZXJ5/X19pbWFnZV9fZXJy/b3JfX3dhcm5pbmct/MTI4LnBuZw";
            foreach (Pokemon Aux in AuxPokemonList)
            {
                Aux.Url = ToValidateImageUrl(Aux.Url) ? Aux.Url : DefaultImage;
            }
        }

        private bool ToValidateImageUrl(string Url)
        {
            try
            {
                if( ! Uri.IsWellFormedUriString(Url, UriKind.Absolute))
                {
                    throw new UriFormatException();
                }

                var Request = (HttpWebRequest)WebRequest.Create(Url);
                Request.Method = "HEAD";
                Request.Timeout = 5000;

                using (var Response = (HttpWebResponse)Request.GetResponse())
                {
                    HttpStatusCode CodeOfStatus = Response.StatusCode;
                    string TypeOfContent=Response.ContentType.ToLower();    
                    if((CodeOfStatus == HttpStatusCode.OK) && (TypeOfContent.StartsWith("image")) )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }catch(UriFormatException ex)
            {
                Session.Add("UriFormatExceptionError", ex.ToString());
                return false;
            }catch(WebException ex)
            {
                if (ex.Response is HttpWebResponse HttpResponse)
                {
                    if (HttpResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        Session.Add("NotFoundError404", ex.ToString());
                    }
                    else if (HttpResponse.StatusCode == HttpStatusCode.Forbidden)
                    {
                        Session.Add("Forbidden403", ex.ToString());
                    }
                    else
                    {
                        Session.Add("HTTPError", ex.ToString());
                    }
                }
                else
                {
                    Session.Add("WebExceptionError", ex.ToString());
                }

                return false;
            }
            catch(Exception ex)
            {
                Session.Add("NotAnWebExceptionError", ex.ToString());
                return false;
            }

        }
    }
}