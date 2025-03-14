using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccess;
using Domain;

namespace Business
{
    public class PokemonBusiness
    {

        private Data Data { get; set; }
        public PokemonBusiness()
        {
            Data = new Data();
        }


        public List<Pokemon> ToList()
        {
            List<Pokemon> Pokemons = new List<Pokemon>();

            try
            {

                Data.SetProcedure("StoredToList");

                Data.OpenConnection();


                Data.ReadData();


                while (Data.Reader.Read())
                {

                    Pokemon Aux = new Pokemon();
                    const int InvalidNumber = -1;

                    Aux.Id = ((int)Data.Reader["Id"] > 0) ? (int)Data.Reader["Id"] : InvalidNumber;
                    Aux.Number = ((int)Data.Reader["Number"] > 0) ? (int)Data.Reader["Number"] : InvalidNumber;

                    Aux.Name = !(Data.Reader["Name"] is DBNull) ? (String)Data.Reader["Name"] : "";
                    Aux.Description = !(Data.Reader["Description"] is DBNull) ? (string)Data.Reader["Description"] : "";


                    if ((!(Data.Reader["TypeId"] is DBNull)) && ((int)Data.Reader["TypeId"] > 0))
                    {
                        Aux.Type.Id = (int)Data.Reader["TypeId"];
                    }
                    else
                    {
                        Aux.Type.Id = InvalidNumber;
                    }
                    Aux.Type.Description = !(Data.Reader["ElementTypeDescription"] is DBNull) ? (string)Data.Reader["ElementTypeDescription"] : "";


                    if ((!(Data.Reader["WeaknessId"] is DBNull)) && ((int)Data.Reader["WeaknessId"] > 0))
                    {
                        Aux.Weakness.Id = (int)Data.Reader["WeaknessId"];
                    }
                    else
                    {
                        Aux.Weakness.Id = InvalidNumber;
                    }
                    Aux.Weakness.Description = !(Data.Reader["ElementWeaknessDescription"] is DBNull) ? (string)Data.Reader["ElementWeaknessDescription"] : "";

                    Aux.Url = !(Data.Reader["ImageUrl"] is DBNull) ? (string)Data.Reader["ImageUrl"] : "";


                    if ((Aux.Id > 0) && (Aux.Number > 0) && (!string.IsNullOrEmpty(Aux.Name)))
                    {
                        Pokemons.Add(Aux);
                    }

                }
                if (Pokemons.Count > 0)
                {
                    return Pokemons;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Data.CloseConnection();
            }
        }

        public Pokemon ToGetPokemon(string Id)
        {
            Pokemon Poke = new Pokemon();
            const int InvalidNumber = -1;

            try
            {
                Data.SetProcedure("StoredToGet");

                if (!(string.IsNullOrEmpty(Id)))
                {
                    Data.AddParameters("@Id", Id);
                }

                Data.OpenConnection();
                Data.ReadData();

                while (Data.Reader.Read())
                {
                    Poke.Id = ((int)Data.Reader["Id"] > 0) ? (int)Data.Reader["Id"] : InvalidNumber;
                    Poke.Number = ((int)Data.Reader["Number"] > 0) ? (int)Data.Reader["Number"] : InvalidNumber;

                    Poke.Name = !(Data.Reader["Name"] is DBNull) ? (String)Data.Reader["Name"] : "";
                    Poke.Description = !(Data.Reader["Description"] is DBNull) ? (string)Data.Reader["Description"] : "";


                    if ((!(Data.Reader["TypeId"] is DBNull)) && ((int)Data.Reader["TypeId"] > 0))
                    {
                        Poke.Type.Id = (int)Data.Reader["TypeId"];
                    }
                    else
                    {
                        Poke.Type.Id = InvalidNumber;
                    }
                    Poke.Type.Description = !(Data.Reader["ElementTypeDescription"] is DBNull) ? (string)Data.Reader["ElementTypeDescription"] : "";


                    if ((!(Data.Reader["WeaknessId"] is DBNull)) && ((int)Data.Reader["WeaknessId"] > 0))
                    {
                        Poke.Weakness.Id = (int)Data.Reader["WeaknessId"];
                    }
                    else
                    {
                        Poke.Weakness.Id = InvalidNumber;
                    }
                    Poke.Weakness.Description = !(Data.Reader["ElementWeaknessDescription"] is DBNull) ? (string)Data.Reader["ElementWeaknessDescription"] : "";

                    Poke.Url = !(Data.Reader["ImageUrl"] is DBNull) ? (string)Data.Reader["ImageUrl"] : "";

                }


                if ((Poke.Id > 0) && (Poke.Number > 0) && (!string.IsNullOrEmpty(Poke.Name)))
                {
                    return Poke;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Data.CloseConnection();
            }
        }

        public List<Pokemon> ToListRecyclingBin()
        {
            List<Pokemon> Pokemons = new List<Pokemon>();

            try
            {
                Data.SetProcedure("StoredToListRecyclingBin");
                Data.OpenConnection();
                Data.ReadData();

                while (Data.Reader.Read())
                {
                    Pokemon Aux = new Pokemon();
                    const int InvalidNumber = -1;

                    Aux.Id = ((int)Data.Reader["Id"] > 0) ? (int)Data.Reader["Id"] : InvalidNumber;
                    Aux.Number = ((int)Data.Reader["Number"] > 0) ? (int)Data.Reader["Number"] : InvalidNumber;

                    Aux.Name = !(Data.Reader["Name"] is DBNull) ? (String)Data.Reader["Name"] : "";
                    Aux.Description = !(Data.Reader["Description"] is DBNull) ? (string)Data.Reader["Description"] : "";


                    if ((!(Data.Reader["TypeId"] is DBNull)) && ((int)Data.Reader["TypeId"] > 0))
                    {
                        Aux.Type.Id = (int)Data.Reader["TypeId"];
                    }
                    else
                    {
                        Aux.Type.Id = InvalidNumber;
                    }
                    Aux.Type.Description = !(Data.Reader["ElementTypeDescription"] is DBNull) ? (string)Data.Reader["ElementTypeDescription"] : "";


                    if ((!(Data.Reader["WeaknessId"] is DBNull)) && ((int)Data.Reader["WeaknessId"] > 0))
                    {
                        Aux.Weakness.Id = (int)Data.Reader["WeaknessId"];
                    }
                    else
                    {
                        Aux.Weakness.Id = InvalidNumber;
                    }
                    Aux.Weakness.Description = !(Data.Reader["ElementWeaknessDescription"] is DBNull) ? (string)Data.Reader["ElementWeaknessDescription"] : "";

                    Aux.Url = !(Data.Reader["ImageUrl"] is DBNull) ? (string)Data.Reader["ImageUrl"] : "";


                    if ((Aux.Id > 0) && (Aux.Number > 0) && (!string.IsNullOrEmpty(Aux.Name)))
                    {
                        Pokemons.Add(Aux);
                    }
                }

                if (Pokemons.Count > 0)
                {
                    return Pokemons;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Data.CloseConnection();
            }

        }

        private bool ToValidatePokemonFields(Object Field)
        {
            bool Flag = false;

            if (Field is int IntNumber)
            {
                //I always ask if a number is greater than 0 because an Id or a pokemon's number could not be below than zero
                Flag = IntNumber > 0 ? true : false;
                return Flag;
            }
            else if (Field is string Text)
            {
                Flag = !string.IsNullOrEmpty(Text) ? true : false;
                return Flag;
            }
            else if (Field is Element)
            {
                //Acá este paso no es necesario porque ya al validar si es un elemento, obviamente no va a ser null, porque null es null
                //Flag = Field != null ? true : false;
                return Flag = true;
            }

            return Flag;
        }

        private void AddParametersOrDBNull(string ParameterName, Object Value)
        {
            var ValueToAdd = ToValidatePokemonFields(Value) ? Value : (Object)DBNull.Value;
            Data.AddParameters(ParameterName, ValueToAdd);
        }


        public void ToAdd(Pokemon NewPokemon)
        {
            try
            {

                if (ToValidatePokemonFields(NewPokemon.Number) && ToValidatePokemonFields(NewPokemon.Name))
                {
                    Data.SetProcedure("StoredToAdd");

                    Data.OpenConnection();

                    Data.AddParameters("@Number", NewPokemon.Number);

                    Data.AddParameters("@Name", NewPokemon.Name);



                    if (ToValidatePokemonFields(NewPokemon.Description))
                    {
                        AddParametersOrDBNull("@Description", NewPokemon.Description);
                    }


                    if (ToValidatePokemonFields(NewPokemon.Url))
                    {
                        AddParametersOrDBNull("@ImageUrl", NewPokemon.Url);

                    }


                    if ((ToValidatePokemonFields(NewPokemon.Type)) && ToValidatePokemonFields(NewPokemon.Type.Id))
                    {

                        AddParametersOrDBNull("@TypeId", NewPokemon.Type.Id);

                    }

                    if (ToValidatePokemonFields(NewPokemon.Weakness) && ToValidatePokemonFields(NewPokemon.Weakness.Id))
                    {
                        AddParametersOrDBNull("@WeaknessId", NewPokemon.Weakness.Id);
                    }

                    //Data.AddParametersOrDBNull("IdEvolucion",null);

                    Data.ExecuteQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Data.CloseConnection();
            }

        }
    
        public void ToUpdate(Pokemon Poke)
        {
            try
            {

                if (ToValidatePokemonFields(Poke.Id) && ToValidatePokemonFields(Poke.Number) && ToValidatePokemonFields(Poke.Name))
                {
                    Data.SetProcedure("StoredToUpdate");

                    Data.OpenConnection();

                    Data.AddParameters("@Number", Poke.Number);
                    Data.AddParameters("@Name", Poke.Name);

                    AddParametersOrDBNull("@Description", Poke.Description);
                    AddParametersOrDBNull("@ImageUrl", Poke.Url);


                    if (ToValidatePokemonFields(Poke.Type))
                    {
                        AddParametersOrDBNull("@TypeId", Poke.Type.Id);
                    }

                    if (ToValidatePokemonFields(Poke.Weakness))
                    {
                        AddParametersOrDBNull("@WeaknessId", Poke.Weakness.Id);

                    }

                    Data.AddParameters("@PokemonId", Poke.Id);


                    Data.ExecuteQuery();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Data.CloseConnection();
            }

        }

        public void Delete(int Id)
        {
            try
            {
                if (ToValidatePokemonFields(Id))
                {
                    Data.SetProcedure("StoredToDelete");

                    Data.OpenConnection();

                    AddParametersOrDBNull("@Id", Id);

                    Data.ExecuteQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Data.CloseConnection();
            }
        }

        public void ToLogicalDelete(int Id)
        {
            try
            {
                if (ToValidatePokemonFields(Id))
                {

                    Data.SetProcedure("StoredToLogicalDelete");
                    Data.OpenConnection();

                    AddParametersOrDBNull("@Id", Id);

                    Data.ExecuteQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Data.CloseConnection();
            }
        }

        public void ToRestorePokemon(int Id)
        {
            try
            {
                if (ToValidatePokemonFields(Id))
                {
                    Data.SetProcedure("StoredToRestorePokemon");
                    Data.OpenConnection();

                    Data.AddParameters("@Id", Id);

                    Data.ExecuteQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Data.CloseConnection();
            }
        }

        public List<Pokemon> ToFilter(string field, string criteria, string filter)
        {
            //Tengo que ver cómo hago esto por procedimiento almacenado 
            List<Pokemon> pokemons = new List<Pokemon>();
            try
            {
                string query = "select P.Id, P.Numero,P.Nombre,P.Descripcion,P.IdTipo,P.IdDebilidad,T.Id,T.Descripcion as Elemento,W.ID,W.Descripcion as Debilidad,p.UrlImagen,P.Activo from POKEMONS as P, ELEMENTOS as T,ELEMENTOS as W where P.IdTipo=T.Id and P.IdDebilidad=W.Id and Activo=1 and ";
                if (field == "Number")
                {
                    switch (criteria)
                    {
                        //aux = "P.Numero > ";
                        case "Mayor than":
                            query += "P.Numero > " + filter;
                            break;
                        case "Minor than":
                            query += "P.Numero < " + filter;
                            break;
                        case "Equal to":
                            query += "P.Numero = " + filter;
                            break;
                    }
                }
                else if (field == "Name")
                {
                    switch (criteria)
                    {
                        case "Stars with":
                            query += $"P.Nombre like '{filter}%' ";
                            break;
                        case "Ends with":
                            query += $"P.Nombre like '%{filter}' ";
                            break;
                        case "Contains":
                            query += $"P.Nombre like '%{filter}%' ";
                            break;
                    }
                }
                else
                {
                    switch (criteria)
                    {
                        case "Stars with":
                            query += $"P.Descripcion like '{filter}%' ";
                            break;
                        case "Ends with":
                            query += $"P.Descripcion like '%{filter}' ";
                            break;
                        case "Contains":
                            query += $"P.Descripcion like '%{filter}%' ";
                            break;
                    }
                }

                Data.SetQuery(query);
                Data.OpenConnection();

                Data.ReadData();
                while (Data.Reader.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)Data.Reader["Id"];
                    aux.Number = (int)Data.Reader["Numero"];
                    aux.Name = (string)Data.Reader["Nombre"];
                    aux.Description = (string)Data.Reader["Descripcion"];

                    //aux.Type = new Element();
                    //aux.Weakness = new Element();
                    aux.Type.Id = (int)Data.Reader["IdTipo"];
                    aux.Type.Description = (string)Data.Reader["Elemento"];

                    aux.Weakness.Id = (int)Data.Reader["IdDebilidad"];
                    aux.Weakness.Description = (string)Data.Reader["Debilidad"];


                    if (!(Data.Reader["UrlImagen"] is DBNull))
                    {
                        aux.Url = (string)Data.Reader["UrlImagen"];
                    }

                    aux.Active = (bool)Data.Reader["Activo"];

                    pokemons.Add(aux);
                }

                return pokemons;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Data.CloseConnection();
            }



        }
















    }
}
