using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ElementBusiness
    {

        private Data Data { get; set; }


        public ElementBusiness()
        {
            Data = new Data();
        }
        public List<Element> ToList()
        {
            //Ac+a tengo que decidir si uso el de procedimiento almacenado o éste   
            List<Element> Elements = new List<Element>();
            
            try
            {

                Data.SetQuery("select E.Id,E.Description from ELEMENTS E");

                Data.OpenConnection();

                Data.ReadData();

                while (Data.Reader.Read())
                {

                    Element aux = new Element();

                    aux.Id = (int)Data.Reader["Id"];
                    aux.Description = (string)Data.Reader["Description"];

                    Elements.Add(aux);

                }
                return Elements;
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

        public List<Element> toListUsingSP()
        {
            List<Element> Elements = new List<Element>();
            try
            {
                Data.SetProcedure("pokemonTypeStoredToList");
                Data.OpenConnection();
                Data.ReadData();

                while (Data.Reader.Read())
                {
                    Element aux = new Element();

                    aux.Id = (int)Data.Reader["Id"];
                    aux.Description = (string)Data.Reader["Description"];

                    Elements.Add(aux);
                }

                return Elements;
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
