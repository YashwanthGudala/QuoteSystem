using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using log4net;
namespace QuoteSystemDataAccess
{
    public class MetadataDataAccess
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string AddCodeValue(string ListName, CodeValue codevalue)
        {

            if (ListName.Length == 0)
            {
                return "ListName is mandatory";
            }

            if (codevalue == null)
            {
                return "Codevalue pair should be mandatory";
            }

            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    CodeValueList codevaluelist = dbContext.CodeValueLists.Where(C => C.ListName == ListName).FirstOrDefault();
                    if (codevaluelist == null)
                    {
                        return "CodeValueList not existing";
                    }
                    codevaluelist.CodeValues.Add(codevalue);
                    dbContext.SaveChanges();

                    log.Info("Added New Code Value To List : " + ListName);
                    return "Successfully Added";
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw new DatabaseException("Unable to Add New CodeValue to Existing List");
            }
        }

        public static string AddCodeValueList(string ListName)
        {

            if (ListName.Length == 0)
            {
                return "ListName is mandatory";
            }
            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    CodeValueList existinglistname = dbContext.CodeValueLists.Where(C => C.ListName == ListName).FirstOrDefault<CodeValueList>();
                    if (existinglistname != null)
                    {
                        return "List Name Already existing";
                    }
                    CodeValueList CodeList = new CodeValueList();
                    CodeList.ListName = ListName;
                    dbContext.CodeValueLists.Add(CodeList);
                    dbContext.SaveChanges();
                }
                log.Info("Added New Code Value List : " + ListName);
                return "Successfully Added";
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw new DatabaseException("Unable to Add New CodeValueList to DataBase");
            }
        }
        public static List<CodeValue> GetCodeValuesByListName(string ListName)
        {
            CodeValueList codevaluelist;
            List<CodeValue> CodeValues = new List<CodeValue>();

            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    codevaluelist = dbContext.CodeValueLists.Where(C => C.ListName == ListName).FirstOrDefault();

                    if (codevaluelist == null)
                    {
                        return null;
                    }

                    foreach (CodeValue codevalue in codevaluelist.CodeValues.ToList())
                    {
                        CodeValue codeValue = new CodeValue()
                        {
                            Code = codevalue.Code,
                            Value = codevalue.Value
                            
                        };
                        CodeValues.Add(codeValue);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw new DatabaseException("Unable to Fetch code value ");
            }
            log.Info("Fetched Code Values of List : " + ListName);
            return CodeValues;
        }
        public static string GetValueFromCode(String ListName, string Key)
        {
            CodeValueList codevaluelist;
            List<CodeValue> CodeValues = new List<CodeValue>();
            string value = "";

            if (ListName.Length == 0)
            {
                return "ListName is mandatory";
            }

            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    codevaluelist = dbContext.CodeValueLists.Where(C => C.ListName == ListName).FirstOrDefault();
                    if (codevaluelist == null)
                    {
                        return "List Name Not Found";
                    }
                    foreach (var codevalue in codevaluelist.CodeValues)
                    {
                        if (codevalue.Code == Key)
                        {
                            value += codevalue.Value;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw new DatabaseException("Unable to Fetch Value From Database");
            }
            if (value == "")
            {
                return "Code Value Pair Not Found";
            }
            log.Info("Fetched Value of Code : " + Key + "From List : " + ListName);
            return value;
        }
        public static List<CodeValueList> GetAllCodeValueLists()
        {
            List<CodeValueList> codeValueLists;
            try
            {

                using (var dbContext = new QuoteDataModelContainer())
                {
                    codeValueLists = dbContext.CodeValueLists.ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw new DatabaseException("Unable to Load All Codevalues");
            }
            log.Info("Fetched All Code Value Lists");
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

                    if (codeValueList == null)
                    {
                        return "Code Value List Not Found";
                    }

                    foreach (var codelist in codeValueList.CodeValues.ToList())
                    {
                        dbContext.CodeValues.Remove(codelist);
                    }

                    dbContext.CodeValueLists.Remove(codeValueList);

                    dbContext.SaveChanges();


                }
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                throw new DatabaseException("Unable to Delete Code Value List");
            }
            log.Info("Deleted Code Value List : " + ListName);
            return "Deleted Successfully";

        }
        public static string DeleteCodeValue(string ListName, string Code)
        {
            CodeValueList codevaluelist;
            int flag = 0;
            if (ListName.Length == 0)
            {
                return "ListName is mandatory";
            }

            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    codevaluelist = dbContext.CodeValueLists.Where(c => c.ListName == ListName).FirstOrDefault();
                    if (codevaluelist == null)
                    {
                        return "listname not found";
                    }

                    foreach (var codevalue in codevaluelist.CodeValues.ToList())
                    {
                        if (codevalue.Code == Code)
                        {
                            dbContext.CodeValues.Remove(codevalue);
                            flag = 1;
                            dbContext.SaveChanges();
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw new DatabaseException("Unable to delete codevalue");
            }

            if (flag == 0)
            {
                return "Unable to fetch the code";
            }
            log.Info("Deleted a Code Value of Key : " + Code + "From List : " + ListName);
            return "Succesfully deleted";

        }

    }
}
