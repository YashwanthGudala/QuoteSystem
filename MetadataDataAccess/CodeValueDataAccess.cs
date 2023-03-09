using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataModel;

namespace MetadataDataAccess
{
    public class CodeValueDataAccess
    {
        public static string AddCodeValueToList(string ListName ,CodeValue codeValue)
        {


            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    CodeValueList codeval = dbContext.CodeValueLists.Where(c => c.ListName == ListName).FirstOrDefault();

                    if(codeval == null)
                    {
                        return "Code Value List Not Found";
                    }

                    codeval.CodeValues.Add(codeValue);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                return "Something Went Wrong";

                throw;
            }
            return "Successfully Added";

        }

        public static string AddNewCodeValueList(string listName)
        {
            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {

                    CodeValueList codelist = new CodeValueList()
                    {
                        ListName = listName
                    };

                    dbContext.CodeValueLists.Add(codelist);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                return "Something went wrong";

                throw;
            }
            return "Successfully Created";
        }
        public static List<CodeValueList> ViewAllCodeValueLists()
        {
            List<CodeValueList> codeValueLists;
            try
            {
                
                using (var dbContext = new QuoteDataModelContainer())
                {
                    codeValueLists = dbContext.CodeValueLists.ToList();


                }
            }
            catch (Exception)
            {

                throw;
            }

            return codeValueLists;

        }
        public static string DeleteCodeValueList(string ListName)
        {
            CodeValueList codeValueList;
            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    codeValueList = dbContext.CodeValueLists.Where(c => c.ListName == ListName).FirstOrDefault();

                    if(codeValueList == null)
                    {
                        return "Code Value List Not Found";
                    }

                    foreach(var codelist in codeValueList.CodeValues.ToList())
                    {
                        dbContext.CodeValues.Remove(codelist);
                    }

                    dbContext.CodeValueLists.Remove(codeValueList);

                    dbContext.SaveChanges();
                    

                }
            }
            catch (Exception)
            {
                return "Something Went Wrong";

                throw;
            }

            return "Deleted Successfully";

        }

    }
}
