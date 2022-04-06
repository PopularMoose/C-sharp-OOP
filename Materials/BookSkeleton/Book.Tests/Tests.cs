namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        private Book testbook;

        [SetUp]
        public void Setup()
        {
            testbook = new Book("KAKDABUDESHGEI", "Gei");
        }

        [Test]
        public void TestBook()
        {
            Assert.AreEqual("KAKDABUDESHGEI", testbook.BookName);
            Assert.AreEqual("Gei", testbook.Author);
        }
        [Test]
        public void manqk232132()
        {
            Book testvook;
            testvook = new Book("rub","penis");
            Assert.Throws<ArgumentException>(() => testvook = new Book("", "penis")); 
        }

        [Test]
        public void manqk2321323213213()
        {
            Book testvook;
            testvook = new Book("rub", "penis");
            Assert.Throws<ArgumentException>(() => testvook = new Book("rub", ""));
        }

        [Test]
        public void kURA()
        {
            testbook.AddFootnote(6, "kur");
            Assert.AreEqual(testbook.FootnoteCount, 1);
        }

        [Test]

        public void penis()
        {
            testbook.AddFootnote(6, "kur");


            Assert.AreEqual(testbook.FindFootnote(6), "Footnote #6: kur");
        }

        [Test]
        public void manqk()
        {
            testbook.AddFootnote(6, "kur");
            testbook.AlterFootnote(6, "kur1");
            Assert.AreEqual(testbook.FindFootnote(6), "Footnote #6: kur1");

        }

        [Test]
        public void manqk2321()
        {
            testbook.AddFootnote(6, "kur");
            Assert.Throws<InvalidOperationException>(() => testbook.AddFootnote(6, "kur"));

        }
        [Test]
        public void manqk232132132131323()
        {
            testbook.AddFootnote(6, "kur");
            Assert.Throws<InvalidOperationException>(() => testbook.FindFootnote(10));

        }
        [Test]
        public void manqk232141242141243124114221421421414241241242142142142142142142141241142241421414()
        {
            testbook.AddFootnote(6, "kur1");
            Assert.Throws<InvalidOperationException>(() => testbook.AlterFootnote(16, "kur1"));

        }
    }
}