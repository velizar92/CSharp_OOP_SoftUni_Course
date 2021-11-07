using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {

        private BankVault bankVault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            this.bankVault = new BankVault();           
            this.item = new Item("Zako", "1");
        }

        [Test]
        public void Ctor_Should_InitVaultCellsCollection()
        {
            Assert.That(bankVault.VaultCells != null);
        }

        [Test]
        public void VaultCellssProperty_Should_ReturnValidResult()
        {         
            Assert.AreEqual(12, bankVault.VaultCells.Count);
        }


        //-------------------------Add Item part:--------------------------
        [Test]
        public void AddItem_Should_ThrowException_When_CellDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("YT", null));
        }

        
        [Test]
        public void AddItem_Should_ThrowException_When_TheContentOfCellIsAlreadyFull()
        {
            Item testItem = new Item("Zako2", "2");
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", testItem));
        }

        [Test]
        public void AddItem_Should_ThrowException_When_ItemIsAlreadyInTheCell()
        {
            Item testItem = new Item("Zako3", "3");
            bankVault.AddItem("A1", testItem);
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A4", testItem));
        }

        [Test]
        public void AddItem_Should_AddItem_InValidWay()
        {
            Item testItem = new Item("Zako", "1");
            bankVault.AddItem("A1", testItem);
            Assert.AreEqual(testItem, bankVault.VaultCells["A1"]);
        }


        //-------------------------Remove Item part:--------------------------

        [Test]
        public void RemoveItem_Should_ThrowException_When_VaultCell_IsNot_In_TheCollection()
        {                    
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("G5", null));
        }

        [Test]
        public void RemoveItem_Should_ThrowException_When_PassedItem_Doesnt_Exists_In_PassedCell()
        {
            Item testItem = new Item("Zako", "4");
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", testItem));
        }

        [Test]
        public void RemoveItem_Should_Remove_Passed_Item()
        {
            Item testItem = new Item("Zako", "4");
            bankVault.AddItem("A1", testItem);
            bankVault.RemoveItem("A1", testItem);
            Assert.AreEqual(null, bankVault.VaultCells["A1"]);
        }


    }
}