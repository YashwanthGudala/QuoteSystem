using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataModel;
using QuoteSystemDataAccess;

namespace QuoteSystemDataAccessTest
{
    public class TestMetadataDataAccess
    {
        public static void AddCodeValueToListTest()
        {
            Console.WriteLine("Enter List Name");
            string listname = Console.ReadLine();
            Console.WriteLine("Enter Code : ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter Value : ");
            string value = Console.ReadLine();

            CodeValue codeValue = new CodeValue()
            {
                Code = code,
                Value = value
            };


            string res = QuoteSystemDataAccess.MetadataDataAccess.AddCodeValue(listname, codeValue);
            Console.WriteLine(res);

        }
        public static void AddNewCodeValueListTest()
        {
            Console.WriteLine("Enter List Name");
            string newlist = Console.ReadLine();

            string res = QuoteSystemDataAccess.MetadataDataAccess.AddCodeValueList(newlist);
            Console.WriteLine(res);
        }
        public static void ViewAllCodeValueListsTest()
        {
            List<CodeValueList> codeValueLists = QuoteSystemDataAccess.MetadataDataAccess.GetAllCodeValueLists();

            foreach (var list in codeValueLists)
            {
                Console.WriteLine(list.ListName);
            }
        }
        public static void DeleteCodeValueListTest()
        {
            Console.WriteLine("Enter List name");
            string listname = Console.ReadLine();
            string res = QuoteSystemDataAccess.MetadataDataAccess.DeleteCodeValueList(listname);
            Console.WriteLine(res);
        }
        public static void GetCodeValuesByListNameTest()
        {
            Console.WriteLine("Enter List Name");
            string listname = Console.ReadLine();
            List<CodeValue> codeValues = QuoteSystemDataAccess.MetadataDataAccess.GetCodeValuesByListName(listname);

            if (codeValues == null)
            {
                Console.WriteLine("No records Found");
            }
            else
            {
                foreach (var code in codeValues)
                {
                    Console.WriteLine(code.Code + " " + code.Value);
                }

            }



        }
        public static void GetValueFromCodeTest()
        {
            Console.WriteLine("Enter List Name");
            string listname = Console.ReadLine();

            Console.WriteLine("Enter Code");
            string Code = Console.ReadLine();

            string res = QuoteSystemDataAccess.MetadataDataAccess.GetValueFromCode(listname, Code);

            Console.WriteLine(res);

        }
        public static void DeleteCodeValueTest()
        {
            Console.WriteLine("Enter List Name");
            string listname = Console.ReadLine();

            Console.WriteLine("Enter Code");
            string Code = Console.ReadLine();

            string res = QuoteSystemDataAccess.MetadataDataAccess.DeleteCodeValue(listname, Code);

            Console.WriteLine(res);

        }



    }
}
