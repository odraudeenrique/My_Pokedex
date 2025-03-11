using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Business;
using System.Web.DynamicData;
using System.Net;
using System.Security.Policy;
using static System.Net.WebRequestMethods;

namespace My_Pokedex
{
    public partial class PokemonDetail : System.Web.UI.Page
    {
        public Pokemon Poke { get; set; } 
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonBusiness Business =new PokemonBusiness();
            List<Pokemon> Pokemons = Business.ToList();



            if (! string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int Id;
                const int InvalidNumber = -1;

                if ((int.TryParse(Request.QueryString["Id"], out Id)))
                {
                    Id = (Id > 0) ? Id : InvalidNumber;
                }
                else
                {
                    Id=InvalidNumber;
                }

                if (Id != InvalidNumber)
                {
                    Poke = ToFindPokemon(Id, Pokemons);
                    string DefaultPokemonPicture= "https://imgs.search.brave.com/k8au3W5lzEHwHuZTUDauZnE0D5rjuEP2KE8Qbh1lOio/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9jZG4w/Lmljb25maW5kZXIu/Y29tL2RhdGEvaWNv/bnMvaW50ZXJhY3Rp/b24tNS83MC9waWN0/dXJlX19nYWxsZXJ5/X19pbWFnZV9fZXJy/b3JfX3dhcm5pbmct/MTI4LnBuZw";
                    Poke.Url = ToValidateImageUrl(Poke.Url) ? Poke.Url : DefaultPokemonPicture;
                }

     
            
            }
        }

        private Pokemon ToFindPokemon(int Id, List<Pokemon> Pokemons)
        {
            Pokemon Aux = new Pokemon();

            foreach (Pokemon Pokemon in Pokemons)
            {
                if (Id == Pokemon.Id)
                {
                    Aux = Pokemon;
                    return Pokemon;
                }
            }

            return null;
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if((Poke is Pokemon)&& (Poke.Id > 0))
            {
                int Id=Poke.Id;
                if(Id > 0)
                {
                    PokemonBusiness Business =new PokemonBusiness();
                    if(Business != null)
                    {
                        Business.ToLogicalDelete(Id);
                    }
                }
                Response.Redirect("RecyclingBin.aspx");
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if ((Poke is Pokemon) && (Poke.Id > 0))
            {
                string Id = Poke.Id.ToString();
                Response.Redirect("AddPokemon.aspx?Id=" + Id);
            }
        }

        private bool ToValidateImageUrl(string Url)
        {
            try
            {
                if(!Uri.IsWellFormedUriString(Url, UriKind.Absolute))
                {
                    throw new UriFormatException();
                }

                var Request=  (HttpWebRequest)WebRequest.Create(Url);
                Request.Method = "HEAD";
                Request.Timeout = 5000;

                using(var Response = (HttpWebResponse)Request.GetResponse())
                {
                    HttpStatusCode Status = Response.StatusCode;
                    string TypeOfContent=Response.ContentType.ToLower();   

                    if((Status==HttpStatusCode.OK) && (TypeOfContent.StartsWith("image")) )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }   
            }catch (UriFormatException ex)
            {
                Session.Add("UriFormatExceptionError", ex.ToString());
                return false;
            }
            catch (WebException ex)
            {
                if(ex.Response is HttpWebResponse HttpResponse)
                {
                    if (HttpResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        Session.Add("NotFoundError404", ex.ToString());
                    }else if(HttpResponse.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Session.Add("Forbidden403", ex.ToString());
                    }
                    else
                    {
                        Session.Add("HttpError", ex.ToString());
                    }
                    return false;
                }
                else
                {
                    Session.Add("WebExceptionError", ex.ToString());
                    return false;
                }
                
            }catch(Exception ex)
            {
                Session.Add("NotAnWebExceptionError", ex.ToString());
                return false;
            }
        }




    }
}