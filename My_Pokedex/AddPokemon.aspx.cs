using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using System.Xml.Linq;
using System.Web.DynamicData;
using System.Net;
using System.Linq.Expressions;

namespace My_Pokedex
{
    public partial class AddPokemon : System.Web.UI.Page
    {
        public string UrlImage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            TxtId.Enabled = false;
            TxtId.Visible = false;

            try
            {
                //Initial configutation for the page
                if (!IsPostBack)
                {
                    ElementBusiness ElementBusiness = new ElementBusiness();
                    List<Element> ElementTypes = ElementBusiness.ToList()/*.ToList()*/;

                    if (ElementTypes != null)
                    {

                        DdlType.DataSource = ElementTypes;
                        DdlType.DataTextField = "Description";
                        DdlType.DataValueField = "Id";
                        DdlType.DataBind();
                    }


                    List<Element> ElementWeaknesses = ElementBusiness.ToList()/*.ToList()*/;

                    if (ElementWeaknesses != null)
                    {
                        DdlWeakness.DataSource = ElementWeaknesses;
                        DdlWeakness.DataTextField = "Description";
                        DdlWeakness.DataValueField = "Id";
                        DdlWeakness.DataBind();

                    }


                    string ImgUrlString = "https://imgs.search.brave.com/k8au3W5lzEHwHuZTUDauZnE0D5rjuEP2KE8Qbh1lOio/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9jZG4w/Lmljb25maW5kZXIu/Y29tL2RhdGEvaWNv/bnMvaW50ZXJhY3Rp/b24tNS83MC9waWN0/dXJlX19nYWxsZXJ5/X19pbWFnZV9fZXJy/b3JfX3dhcm5pbmct/MTI4LnBuZw";
                    ImgPokemon.ImageUrl = ImgUrlString;

                    //This is for update the pokemon on the database
                    string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                    if (!(string.IsNullOrEmpty(Id)))
                    {
                        PokemonBusiness Business = new PokemonBusiness();
                        Pokemon Poke = Business.ToGetPokemon(Id);
                        TxtNumber.ReadOnly = true;
                        ToGetPokemonToModify(Poke);
                        BtnAdd.Text = "Update";

                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }


        }



        private void ToGetPokemonToModify(Pokemon Poke)
        {

            if (Poke != null)
            {
                TxtId.Text = Poke.Id > 0 ? Poke.Id.ToString() : "";
                TxtName.Text = !(string.IsNullOrEmpty(Poke.Name)) ? Poke.Name : "";
                TxtNumber.Text = Poke.Number > 0 ? Poke.Number.ToString() : "";
                TxtDescription.Text = (!(string.IsNullOrEmpty(Poke.Description)) && (Poke.Description.Length < 298)) ? Poke.Description : ""; //i´m doing this because I want to know the description´s length for not having problems with the database



                if ((Poke.Type != null) && (Poke.Type.Id > 0))
                {
                    ListItem SelectedTypeForDropdownList = DdlType.Items.FindByValue(Poke.Type.Id.ToString());

                    if (SelectedTypeForDropdownList != null)
                    {
                        DdlType.ClearSelection();
                        SelectedTypeForDropdownList.Selected = true;
                    }
                }

                if ((Poke.Weakness != null) && (Poke.Weakness.Id > 0))
                {
                    ListItem SelectedWeaknessForDropdownList = DdlWeakness.Items.FindByValue(Poke.Weakness.Id.ToString());

                    if (SelectedWeaknessForDropdownList != null)
                    {
                        DdlWeakness.ClearSelection();
                        SelectedWeaknessForDropdownList.Selected = true;
                    }

                }

                if (!string.IsNullOrEmpty(Poke.Url)  && (ToValidateImageUrl(Poke.Url))  )
                {
                    
                    TxtUrl.Text = Poke.Url;
                    ImgPokemon.ImageUrl = TxtUrl.Text;
                }
                else
                {
                    ImgPokemon.ImageUrl = "https://imgs.search.brave.com/k8au3W5lzEHwHuZTUDauZnE0D5rjuEP2KE8Qbh1lOio/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9jZG4w/Lmljb25maW5kZXIu/Y29tL2RhdGEvaWNv/bnMvaW50ZXJhY3Rp/b24tNS83MC9waWN0/dXJlX19nYWxsZXJ5/X19pbWFnZV9fZXJy/b3JfX3dhcm5pbmct/MTI4LnBuZw";
                }

            }
        }



        protected void TxtUrl_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtUrl.Text.Trim()))
            {
                if (ToValidateImageUrl(TxtUrl.Text.Trim()))
                {
                    ImgPokemon.ImageUrl = TxtUrl.Text;
                }
                else
                {
                    ImgPokemon.ImageUrl = "https://imgs.search.brave.com/k8au3W5lzEHwHuZTUDauZnE0D5rjuEP2KE8Qbh1lOio/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9jZG4w/Lmljb25maW5kZXIu/Y29tL2RhdGEvaWNv/bnMvaW50ZXJhY3Rp/b24tNS83MC9waWN0/dXJlX19nYWxsZXJ5/X19pbWFnZV9fZXJy/b3JfX3dhcm5pbmct/MTI4LnBuZw";

                }
            }
            else
            {
                ImgPokemon.ImageUrl = "https://imgs.search.brave.com/k8au3W5lzEHwHuZTUDauZnE0D5rjuEP2KE8Qbh1lOio/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9jZG4w/Lmljb25maW5kZXIu/Y29tL2RhdGEvaWNv/bnMvaW50ZXJhY3Rp/b24tNS83MC9waWN0/dXJlX19nYWxsZXJ5/X19pbWFnZV9fZXJy/b3JfX3dhcm5pbmct/MTI4LnBuZw";
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

                var Request=(HttpWebRequest)WebRequest.Create(Url);

                Request.Method = "HEAD";    
                Request.Timeout = 5000;

                using(var Response =(HttpWebResponse)Request.GetResponse())
                {
                    HttpStatusCode StatusCode = Response.StatusCode;
                    string TypeOfContent=Response.ContentType.ToLower();

                    if((StatusCode == HttpStatusCode.OK) && (TypeOfContent.StartsWith("image")))
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
                Session.Add("UriFormatExceptionError",ex.ToString());
                return false;
            }
            catch (WebException ex)
            {
                if(ex.Response is HttpWebResponse HttpResponse)
                {
                    if(HttpResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        Session.Add("NotFoundError404",ex.ToString()); 
                    }else if(HttpResponse.StatusCode == HttpStatusCode.Forbidden)
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
                    Session.Add("WebExceptionError", ex.ToString() );   
                }

                return false;
            }
            catch(Exception ex)
            {
                Session.Add("NotAnWebExceptionError",ex.ToString() );
                return false;
            }
        }
        protected void TxtDescription_TextChanged(object sender, EventArgs e)
        {
            if ((TxtDescription.Text.Length > 298) && (!(string.IsNullOrEmpty(TxtDescription.Text))))
            {
                ErrorLabel.Text = "An error has occour; try to just write less than 50 characters or less than 10 words on the description";
                BtnAdd.Enabled = false;
            }
            else
            {
                ErrorLabel.Text = "";
                BtnAdd.Enabled = true;

            }
        }


        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                BtnAdd.Enabled = false;

                Pokemon Aux = new Pokemon();
                PokemonBusiness Business = new PokemonBusiness();

                int AuxNumber;
                const int InvalidIdOrNumber = -1;
                const int MaxNumberOfCharacters = 298;


                Aux.Name = !string.IsNullOrEmpty(TxtName.Text) ? TxtName.Text : "";

                if (int.TryParse(TxtNumber.Text, out AuxNumber))
                {
                    Aux.Number = AuxNumber;
                }
                else
                {
                    Aux.Number = InvalidIdOrNumber;
                }



                if ((!string.IsNullOrEmpty(TxtDescription.Text)) && (TxtDescription.Text.Length < MaxNumberOfCharacters))
                {
                    Aux.Description = TxtDescription.Text;

                }
                else
                {
                    ErrorLabel.Text = "An error has occour; try to just write less than 50 characters or less than 10 words on the description";
                }



                Aux.Url = !string.IsNullOrEmpty(TxtUrl.Text) ? TxtUrl.Text : "";


                if (!string.IsNullOrEmpty(DdlType.SelectedValue))
                {
                    int TypeId;

                    if (int.TryParse(DdlType.SelectedValue, out TypeId))
                    {
                        Aux.Type.Id = TypeId;
                    }
                    else
                    {
                        Aux.Type.Id = InvalidIdOrNumber;
                    }
                }

                if (!string.IsNullOrEmpty(DdlWeakness.SelectedValue))
                {
                    int WeaknessId;

                    if (int.TryParse(DdlWeakness.SelectedValue, out WeaknessId))
                    {
                        Aux.Weakness.Id = WeaknessId;
                    }
                    else
                    {
                        Aux.Weakness.Id = InvalidIdOrNumber;
                    }
                }

                List<Pokemon> PokemonsToEvaluate = Business.ToList();

                if (!ToVaidateIfPokemonExists(Aux, PokemonsToEvaluate))
                {
                    //This is for adding a new one
                    if ((!string.IsNullOrEmpty(Aux.Name)) && (Aux.Number > 0))
                    {
                        Business.ToAdd(Aux);
                        BtnAdd.Enabled = true;
                        Response.Redirect("Default.aspx", false);
                    }
                    else
                    {
                        ErrorLabel.Text = "An error has occour; try to check the information you filled on every box, please";
                        BtnAdd.Enabled = true;
                    }

                }
                else
                {
                    //This is for updating an existed one
                    //I asked for the Id in this part, because if the pokemon doesn't exist, It´s going to be created on the database
                    if (!string.IsNullOrEmpty(Aux.Name) && (Aux.Number > 0))
                    {
                        int Id;
                        if (int.TryParse(TxtId.Text, out Id))
                        {
                            Aux.Id = Id > 0 ? Id:InvalidIdOrNumber ;
                        }
                        else
                        {
                            Aux.Id = InvalidIdOrNumber;
                        }

                        if ((Aux.Id > 0) && (Aux.Number > 0) && (!string.IsNullOrEmpty(Aux.Name)) )
                        {
                            Business.ToUpdate(Aux);
                            BtnAdd.Enabled = true;
                            Response.Redirect("Default.aspx", false);
                        }
                        else
                        {
                            return;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        private bool ToVaidateIfPokemonExists(Pokemon Poke, List<Pokemon> Pokemons)
        {
            bool Flag = false;

            foreach (Pokemon Pokemon in Pokemons)
            {
                if (Pokemon.Number == Poke.Number)
                {
                    Flag = true;
                    return Flag;
                }
            }

            return Flag;
        }

        protected void TxtNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int Number;
                if (int.TryParse(TxtNumber.Text, out Number))
                {
                    if (Number > 0)
                    {
                        PokemonBusiness Business = new PokemonBusiness();
                        List<Pokemon> Pokemons = Business.ToList();
                        foreach (Pokemon Poke in Pokemons)
                        {
                            if (Poke.Number == Number)
                            {
                                BtnAdd.Enabled = false;
                                ErrorLabel.Text = "That Pokemon exists on the pokedex.Check the pokemon number you would like to add ";
                                return;
                            }
                            else
                            {
                                BtnAdd.Enabled = true;
                                ErrorLabel.Text = "";

                            }
                        }

                    }
                    else
                    {
                        BtnAdd.Enabled = false;
                        ErrorLabel.Text = "The number must be greater than 0, please";
                        return;
                    }

                }
                else
                {
                    BtnAdd.Enabled = false;
                    ErrorLabel.Text = "Just write numbers on this field, please";
                    return;
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}
