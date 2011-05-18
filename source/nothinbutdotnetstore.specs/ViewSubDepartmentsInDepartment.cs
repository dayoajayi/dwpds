 using System.Collections.Generic;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    [Subject(typeof(ViewSubDepartmentsInDepartment))]
    public class ViewSubDepartmentsInDepartment
    {
        
        public abstract class concern : Observes<IProcessAnApplicationSpecificBehaviour,
                                            ViewSubDepartmentsInDepartment>
        {
        
        }

        public class when_run : concern
        {
            private Establish c = () =>
                                      {
                                          display_engine = depends.on<ICanRenderInformation>();
                                          store_catalog = depends.on<ICanFindDetailsInTheStore>();
                                          request = fake.an<IContainRequestInformation>();

                                          sub_departments = new List<DepartmentItem> {new DepartmentItem()};

                                          store_catalog.setup(x => x.get_the_sub_departments()).Return(sub_departments);
      
                                      };

            private It should_tell_the_main_department_to_display_the_sub_departments =
                () => display_engine.received(x => x.display(sub_departments));
            private static ICanRenderInformation display_engine;
            private static ICanFindDetailsInTheStore store_catalog;
            private static IContainRequestInformation request;
            private static List<DepartmentItem> sub_departments;
        }
    }
}
