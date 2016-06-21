using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Security.Permissions;
using Secure_Library;

namespace Secure_Application_Demo
{
    class BizzLay
    {
        [PrincipalPermissionAttribute(SecurityAction.Demand, Name = "root")]
        public static void allAccess()
        {
            MessageBox.Show("all access!");
        }

        [PrincipalPermissionAttribute(SecurityAction.Demand, Role = Roles.CREATE_USER)]
        public static void createUser()
        {
            MessageBox.Show("stwórz użytkownika");
        }

        [PrincipalPermissionAttribute(SecurityAction.Demand, Role = Roles.DELETE_USER)]
        public static void deleteUser()
        {
            MessageBox.Show("usuń użytkownika");
        }

        [PrincipalPermissionAttribute(SecurityAction.Demand, Role = Roles.CREATE_POST)]
        public static void createPost()
        {
            MessageBox.Show("utwórz wpis");
        }

        [PrincipalPermissionAttribute(SecurityAction.Demand, Role = Roles.MODIFY_POST)]
        public static void modifyPost()
        {
            MessageBox.Show("edytuj wpis");
        }

        [PrincipalPermissionAttribute(SecurityAction.Demand, Role = Roles.DELETE_POST)]
        public static void deletePost()
        {
            MessageBox.Show("usuń wpis");
        }

        [PrincipalPermissionAttribute(SecurityAction.Demand, Role = Roles.GROUP_PERMISSION)]
        public static void groupPermission()
        {
            MessageBox.Show("przypisz uprawnienia grupie");
        }

        [PrincipalPermissionAttribute(SecurityAction.Demand, Role = Roles.USER_PERMISSION)]
        public static void userPermission()
        {
            MessageBox.Show("przypisz uprawnienia użytkownikowi");
        }

        [PrincipalPermissionAttribute(SecurityAction.Demand, Role = Roles.CREATE_GROUP)]
        public static void createGroup()
        {
            MessageBox.Show("utwórz grupę");
        }

        [PrincipalPermissionAttribute(SecurityAction.Demand, Role = Roles.DELETE_GROUP)]
        public static void deleteGroup()
        {
            MessageBox.Show("usuń grupę");
        }

        [PrincipalPermissionAttribute(SecurityAction.Demand, Role = Roles.USER_GROUP)]
        public static void userGroup()
        {
            MessageBox.Show("przypisz użytkowników do grupy");
        }
    }
}
