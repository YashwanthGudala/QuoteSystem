using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetadataDataAccessTest
{
    class DataAccessTest
    {
        static void Main(string[] args)
        {
            //testing add new code list
           //TestMetadataDataAccess.AddCodeValueToListTest();

            int option;
            do
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Meta Data Access");
                Console.WriteLine("1. Add New Code Value List");
                Console.WriteLine("2. View All Code Value List");
                Console.WriteLine("3. Delete Code Value List");
                Console.WriteLine("4. Add Code Value Pair To List");
                Console.WriteLine("5. Exit Application");

                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        TestMetadataDataAccess.AddNewCodeValueListTest();
                        break;

                    case 2:
                        TestMetadataDataAccess.ViewAllCodeValueListsTest();
                        break;

                    case 3:
                        TestMetadataDataAccess.DeleteCodeValueListTest();
                        break;
                    case 4:
                        TestMetadataDataAccess.AddCodeValueToListTest();
                        break;
                }
            } while (option != 5);

        }
    }
}
