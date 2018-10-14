using System;
using System.Collections.Generic;

using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;
using System.Windows.Automation;

namespace addressbook_test_white
{ 
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEWINTITLE = "Delete group";

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
             
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();

            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root =  tree.Nodes[0]; //головной список 
            foreach (TreeNode item in root.Nodes)  //получаем список вложенных элементов
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }
           
            CloseGroupsDialogue(dialogue);
            return list;
        }

        public List<GroupData> GetGroupListRemove()
        {
            List<GroupData> list = new List<GroupData>();

            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0]; //головной список 

            foreach (TreeNode item in root.Nodes)  //получаем список вложенных элементов
            {
                list.Remove(new GroupData()
                {
                    Name = item.Text
                });
            }

            CloseGroupsDialogue(dialogue);
            return list;
        }

        public void Remove(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();

            manager.MainWindow.Get<Button>("uxNewAddressButton").Click();
            TextBox textbox = (TextBox)dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textbox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

            CloseGroupsDialogue(dialogue);

            //uxDeleteAddressButton

        }

        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();

            manager.MainWindow.Get<Button>("uxNewAddressButton").Click();
            TextBox textbox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textbox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

            CloseGroupsDialogue(dialogue);
        }

        public void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

        public Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }
    }
}