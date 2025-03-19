using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Business;
using System.Drawing;
using System.Web.DynamicData;
using System.Net;
using Microsoft.Ajax.Utilities;
using System.Xml.Linq;



namespace My_Pokedex
{
    public partial class _Default : Page
    {
        public List<Pokemon> Pokemons;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                PokemonBusiness PokemonBusiness = new PokemonBusiness();
                Pokemons = PokemonBusiness.ToList();

                ToAssignPicture(Pokemons);

                if (Pokemons != null && Pokemons.Count > 0)
                {
                    Session.Add("AllPokemons", Pokemons);
                }
                else
                {
                    Session["AllPokemons"] = Pokemons;
                }

                RepPokemonCards.DataSource = Session["AllPokemons"];
                RepPokemonCards.DataBind();
            }


        }

        private void ToAssignPicture(List<Pokemon> AuxPokemonList)
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
                if (!Uri.IsWellFormedUriString(Url, UriKind.Absolute))
                {
                    throw new UriFormatException();
                }

                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Url);
                Request.Method = "HEAD";
                Request.Timeout = 10000;

                using (var Response = (HttpWebResponse)Request.GetResponse())
                {
                    HttpStatusCode StatusCode = Response.StatusCode;
                    string TypeOfContent = Response.ContentType.ToLower();

                    if ((StatusCode == HttpStatusCode.OK) && (TypeOfContent.StartsWith("image")))
                    {
                        return true;
                    }
                }

            }
            catch (UriFormatException ex)
            {
                Session.Add("UriFormatExceptionError", ex.ToString());
            }
            catch (WebException ex) when (ex.Response is HttpWebResponse HttpResponse)
            {
                switch (HttpResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        Session.Add("NotFoundError", ex.ToString());
                        return false;
                    case HttpStatusCode.Unauthorized:
                        Session.Add("UnauthorizedError", ex.ToString());
                        return false;
                    case HttpStatusCode.Forbidden:
                        Session.Add("ForbiddenError", ex.ToString());
                        return false;

                }
                return false;
            }
            catch (Exception ex)
            {
                Session.Add("NotAnWebExceptionError", ex.ToString());
            }



            return false;
        }



        protected void BtnViewDetails_Click(object sender, EventArgs e)
        {
            string PokemonId = ((Button)sender).CommandArgument != null ? ((Button)sender).CommandArgument : "";
            if (!(string.IsNullOrEmpty(PokemonId)))
            {
                Response.Redirect("PokemonDetail.aspx?Id=" + PokemonId);

            }

        }
        private List<Pokemon> ToFilterByTypeOrWeakness()
        {

            string FieldToSearch = !string.IsNullOrEmpty(TxtSearchWithoutDB?.Text) ? TxtSearchWithoutDB.Text.Trim() : "";
            string SelectedValue = DdlTypeOfSearch.SelectedValue;
            string SelectedElement= !string.IsNullOrEmpty(DdlElementsForSearch?.SelectedValue)?  DdlElementsForSearch.SelectedValue.ToLower():null;


            if (!string.IsNullOrEmpty(SelectedValue) && (!string.IsNullOrEmpty(SelectedElement)) && (Session["AllPokemons"] != null))
            {

                //if ((!int.TryParse(FieldToSearch, out int Error)) && (string.IsNullOrEmpty(FieldToSearch)))
                //{
                //    List<Pokemon> FilteredPokemons = ((List<Pokemon>)Session["AllPokemons"]).Where(P => P.Type.Description.ToLower() == SelectedElement.ToLower()).ToList();
                //    if ((FilteredPokemons != null) && (FilteredPokemons.Count > 0))
                //    {
                //        return FilteredPokemons;
                //    }
                //    else
                //    {
                //        return null;
                //    }

                //} else 
                
                if ((!int.TryParse(FieldToSearch, out int Error)) &&( !string.IsNullOrEmpty(SelectedElement)) && (string.IsNullOrEmpty(FieldToSearch)))
                {
                    List<Pokemon> FilteredPokemons;
                    switch (SelectedValue)
                    {
                        case "Pokemon's Type":
                            FilteredPokemons = ((List<Pokemon>)Session["AllPokemons"]).Where(P => (P.Type.Description.ToLower() == SelectedElement)).ToList();
                            if ((FilteredPokemons != null) && (FilteredPokemons.Count > 0))
                            {
                                return FilteredPokemons;
                            }
                            else
                            {
                                return null;
                            }
                        case "Pokemon's Weakness":
                            FilteredPokemons = ((List<Pokemon>)Session["AllPokemons"]).Where(P => (P.Weakness.Description.ToLower() == SelectedElement)).ToList();
                            if ((FilteredPokemons != null) && (FilteredPokemons.Count > 0))
                            {
                                return FilteredPokemons;
                            }
                            else
                            {
                                return null;
                            }
                        default:
                            return null;
                    }

                }
                else if ((!int.TryParse(FieldToSearch, out int Error2))&& !string.IsNullOrEmpty(SelectedElement) && (!string.IsNullOrEmpty(FieldToSearch)))
                {
                    List<Pokemon> FilteredPokemons;
                    switch (SelectedValue)
                    {
                        case "Pokemon's Type":
                            FilteredPokemons = ((List<Pokemon>)Session["AllPokemons"]).Where(P => (P.Name.ToLower().Contains(FieldToSearch.ToLower())) && (P.Type.Description.ToLower()==SelectedElement)    ).ToList();
                            if ((FilteredPokemons != null) && (FilteredPokemons.Count > 0))
                            {
                                return FilteredPokemons;
                            }
                            else
                            {
                                return null;
                            }
                        case "Pokemon's Weakness":
                            FilteredPokemons = ((List<Pokemon>)Session["AllPokemons"]).Where(P => P.Name.Contains(FieldToSearch.ToLower()) && (P.Weakness.Description.ToLower() == SelectedElement)).ToList();
                            if ((FilteredPokemons != null) && (FilteredPokemons.Count > 0))
                            {
                                return FilteredPokemons;
                            }
                            else
                            {
                                return null;
                            }
                        default:
                            return null;
                    }

                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }
        private void ToFilter()
        {
            string SelectedValue = DdlTypeOfSearch.SelectedValue;
            if (SelectedValue == "Name or Number")
            {
                //Acá tengo que ver cómo hago cuando el textbox esté vacio que me devuelva a todos los pokemones o me devuelva a los del tipo. Seguramente es si está vacio y está seleccionado
                //el name or number
                ToFilterByName();
            }
            else if(SelectedValue== "Pokemon's Type" || SelectedValue == "Pokemon's Weakness")
            {
                List<Pokemon>FilteredList=ToFilterByTypeOrWeakness();

                if((FilteredList != null) && (FilteredList.Count>0))
                {
                    RepPokemonCards.GetDefaultValues();
                    RepPokemonCards.DataSource = FilteredList;
                    RepPokemonCards.DataBind();
                }
                else
                {
                    RepPokemonCards.GetDefaultValues();
                    RepPokemonCards.DataSource = null;
                    RepPokemonCards.DataBind();
                }
             
            }
        }
        private List<Element> ToGetElementsToFilter()
        {
            ElementBusiness Business = new ElementBusiness();   
            List<Element>ElementsToFilter= Business!=null? Business.ToList(): null;

            if((ElementsToFilter != null)&& (ElementsToFilter.Count > 0))
            {
                return ElementsToFilter;
            }
            else
            {
                return null;    
            }
        }
        private void ToFilterByName()
        {
            string FieldToSearch = !string.IsNullOrEmpty(TxtSearchWithoutDB.Text) ? TxtSearchWithoutDB.Text.Trim() : "";


            int PokemonNumber;

            if ((int.TryParse(FieldToSearch, out PokemonNumber)) && (!string.IsNullOrEmpty(FieldToSearch)) && (Session["AllPokemons"] != null))
            {
                if (PokemonNumber > 0)
                {
                    foreach (Pokemon Poke in ((List<Pokemon>)Session["AllPokemons"]))
                    {
                        if (Poke.Number == PokemonNumber)
                        {
                            //I know it´s going to get a shallow copy, but it doesn't matter, because I'm not chaging anything on the objects
                            List<Pokemon> FilteredPokemons = ((List<Pokemon>)Session["AllPokemons"]).Where(P => P.Number == PokemonNumber).ToList();

                            if (FilteredPokemons != null)
                            {
                                RepPokemonCards.GetDefaultValues();
                                RepPokemonCards.DataSource = FilteredPokemons;
                                RepPokemonCards.DataBind();
                            }
                            else
                            {
                                RepPokemonCards.GetDefaultValues();
                                RepPokemonCards.DataSource = Session["AllPokemons"];
                                RepPokemonCards.DataBind();
                            }
                        }
                    }

                }
                else
                {
                    RepPokemonCards.GetDefaultValues();
                    RepPokemonCards.DataSource = null;
                    RepPokemonCards.DataBind();
                }
            }
            else if ((!string.IsNullOrEmpty(FieldToSearch)))
            {
                List<Pokemon> FilteredPokemons = ((List<Pokemon>)Session["AllPokemons"]).Where(P => DoesThePokemonContainsTheString(P, FieldToSearch)).ToList();

                if (FilteredPokemons != null)
                {
                    RepPokemonCards.GetDefaultValues();
                    RepPokemonCards.DataSource = FilteredPokemons;
                    RepPokemonCards.DataBind();
                }
                else
                {
                    RepPokemonCards.DataSource = Session["AllPokemons"];
                    RepPokemonCards.DataBind();
                }


            }
            else
            {
                RepPokemonCards.GetDefaultValues();
                RepPokemonCards.DataSource = Session["AllPokemons"];
                RepPokemonCards.DataBind();
            }
        }

        protected void TxtSearchWithoutDB_TextChanged(object sender, EventArgs e)
        {
            ToFilter();
        }

        private bool DoesThePokemonContainsTheString(Pokemon Poke, string Field)
        {
            string Name = !string.IsNullOrEmpty(Poke.Name) ? Poke.Name.ToLower() : "";
            string Type = !string.IsNullOrEmpty(Poke.Type?.Description) ? Poke.Type.Description.ToLower() : "";
            string Weakness = !string.IsNullOrEmpty(Poke.Weakness?.Description) ? Poke.Type.Description.ToLower() : "";


            if (Name.Contains(Field.ToLower()))
            {
                return true;
            }
            //else if (Type.Contains(Field.ToLower()))
            //{
            //    return true;
            //}
            //else if (Weakness.Contains(Field.ToLower()))
            //{
            //    return true;
            //}



            return false;
        }

        protected void DdlTypeOfSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Debería cambiar el boton del filtro para restaurar 
            string SelectedValue = DdlTypeOfSearch.SelectedValue;
            if (SelectedValue == "Name or Number")
            {
                //Esto hace falta validarlo y colocarle bootstrap para que se vea bien
                DdlElementsForSearch.Visible = false;
                string TextForSearch=TxtSearchWithoutDB.Text;

                if (TextForSearch == "")
                {
                    RepPokemonCards.GetDefaultValues();
                    RepPokemonCards.DataSource = Session["AllPokemons"];
                    RepPokemonCards.DataBind();
                }
                else
                {
                    ToFilter();
                }
                
            }
            else if (SelectedValue == "Pokemon's Type" || SelectedValue == "Pokemon's Weakness")
            {
                DdlElementsForSearch.Visible = true;
                List<Element> Elements = ToGetElementsToFilter();
                DdlElementsForSearch.DataSource = (Elements.Count > 0) ? Elements : null;
                DataBind();

                ToFilter();
               
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            ToFilter();
        }

        protected void DdlElementsForSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToFilter();
        }
    }
}