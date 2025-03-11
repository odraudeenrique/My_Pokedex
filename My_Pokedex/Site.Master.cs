using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Business;
using System.Drawing;
using System.Web.DynamicData;
using Microsoft.Ajax.Utilities;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace My_Pokedex
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        
        {
            if (!IsPostBack)
            {
                DDLPokemonFilters.Items.Add("Name");
                DDLPokemonFilters.Items.Add("Type");
                DDLPokemonFilters.Items.Add("Weakness");


                int Flag;
                if(int.TryParse(Request.QueryString["Flag"], out Flag))
                {
                    if ((Session["FilterIndex"] != null)  && (Flag>0) )
                    {
                        int IndexValue;

                        if (int.TryParse(Session["FilterIndex"].ToString(), out IndexValue))
                        {
                            DDLPokemonFilters.SelectedIndex = IndexValue >= 0 ? IndexValue : -1;
                        }

                    }

                    if ((Session["FilterText"] != null ) && (Flag > 0))
                    {
                        TxtSearch.Text = Session["FilterText"].ToString();
                    }
                }

            }         
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            ToSearchPokemon();

            ToGetFiltersValue();

            string TrueValue = "1";

            Response.Redirect($"ListOfPokemons?Flag={TrueValue}");
        }
        private void ToSearchPokemon()
        {
            string Filter = !string.IsNullOrEmpty(DDLPokemonFilters.SelectedItem?.Value.ToString()) ? DDLPokemonFilters.SelectedItem.Value.ToLower() : "";
            string FilterText = !string.IsNullOrEmpty(TxtSearch.Text) ? TxtSearch.Text : "";

            if (!string.IsNullOrEmpty(Filter))
            {
                List<Pokemon> FilteredList = ToFilter(Filter, FilterText);


                if ((!IsPostBack) && (FilteredList != null) && (FilteredList.Count > 0))
                {
                    Session.Add("FilteredList", FilteredList);
                }
                else if ((FilteredList != null) && (FilteredList.Count > 0))
                {
                    Session["FilteredList"] = FilteredList;
                }
                else
                {
                    Session["FilteredList"] = null;
                }

            }
        }

        private List<Pokemon> ToFilter(string Filter, string FilterText)
        {

            PokemonBusiness Business = new PokemonBusiness();
            List<Pokemon> AllPokemons = Business != null ? Business.ToList() : null;
            if (!string.IsNullOrEmpty(Filter) && (!string.IsNullOrEmpty(FilterText)) && (AllPokemons != null) && (AllPokemons.Count > 0))
            {
                List<Pokemon> FilteredPokemons;

                int Number;
                if (int.TryParse(FilterText, out Number))
                {
                    //If the number is mayor than 0 it's going to show, if it´s an invalid 
                    //number, it´s going to show nothing.
                    if (Number > 0)
                    {
                        FilteredPokemons = AllPokemons.Where(P => P.Number == Number).ToList();

                        if ((FilteredPokemons != null) && (FilteredPokemons.Count > 0))
                        {
                            return FilteredPokemons;
                        }
                    }
                    else
                    {
                        FilteredPokemons = null;
                        return FilteredPokemons;
                    }
                }
                else if(!string.IsNullOrEmpty(FilterText))
                {
                    FilteredPokemons = AllPokemons.Where(P => DoesThePokemonContainsTheString(P, Filter, FilterText)).ToList();

                        //If everything is ok, it´s going to filter, and It's going to return a List. That list could be 
                        //filled with pokemons, or could be filled with nothing, because no pokemon could be found.
                        //In this one, it could show no pokemon in a string that contains random characters, or where there 
                        //isn´t no coicidance
                    if ((FilteredPokemons != null) && (FilteredPokemons.Count > 0))
                    {
                        return FilteredPokemons;
                    }
                    else
                    {
                        return null;
                    }
                }
                //else
                //{
                //    //If the filter's text is empty, it´s going to show all Pokemons  because the search it´s ended. It would be 
                //    //like searching for the original list of pokemons.
                //    return AllPokemons;
                //}

            }
            else
            {
                //If the filed text it´s not a number, or it´s empty, when the TextChanged happened, it's going to redirect to the default page
                //This is for if an error occour.//If the filed text it´s not a number, or it´s empty, when the TextChanged happened, it's going to show all Pokemons 
                //This is for if an error occour.
                Response.Redirect("Default.aspx");
                
            }

            return null;
        }

        private bool DoesThePokemonContainsTheString(Pokemon Aux, string Field, string FilterText)
        {

            if ((!string.IsNullOrEmpty(Field)) && (!string.IsNullOrEmpty(FilterText)))
            {
                ElementBusiness Business = null;
                List<Element> Elements = null;
                switch (Field)
                {
                    case "name":
                        string Name = !string.IsNullOrEmpty(Aux.Name) ? Aux.Name.ToLower() : "";
                        if (!string.IsNullOrEmpty(Name))
                        {
                            if (Name.Contains(FilterText))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        }
                        break;
                    case "type":

                        string Type = !string.IsNullOrEmpty(Aux.Type?.Description) ? Aux.Type.Description.ToLower() : "";
                        Business = new ElementBusiness();
                        Elements = Business != null ? Business.ToList() : null;

                        if ((Elements != null) && (Elements.Count > 0))
                        {
                            foreach (Element Elmt in Elements)
                            {
                                if (Type.Contains(FilterText))
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                        break;
                    case "weakness":
                        string Weakness = !string.IsNullOrEmpty(Aux.Weakness?.Description) ? Aux.Weakness.Description.ToLower() : "";
                        Business = new ElementBusiness();
                        Elements = Business != null ? Business.ToList() : null;

                        if ((Elements != null) && (Elements.Count > 0))
                        {
                            foreach (Element Elmt in Elements)
                            {
                                if (Weakness.Contains(FilterText))
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                        break;
                }

                return false;
            }
            return false;
        }


        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ToSearchPokemon();

            ToGetFiltersValue();

            string TrueValue = "1";

            Response.Redirect($"ListOfPokemons?Flag={TrueValue}");
            
        }

        private void ToGetFiltersValue()
        {
            const int InvalidValue = -1;
            int IndexValue= DDLPokemonFilters.SelectedIndex >= 0? DDLPokemonFilters.SelectedIndex :InvalidValue;
            string TextValue = TxtSearch != null ? TxtSearch.Text : "";

            if((IndexValue >= 0 ) && (Session["FilterIndex"] == null))
            {
                Session.Add("FilterIndex",IndexValue);
                Session.Add("FilterText",TextValue);
            }
            else if((IndexValue >= 0 )&& (Session["FilterIndex"] != null))
            {
                Session["FilterIndex"] = IndexValue;
                Session["FilterText"] =TextValue;
            }
        }


     
    }
}