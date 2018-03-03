using System;
using System.Collections;
using System.Configuration;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjaTests.Fundamentals
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_ArgIsNull_ThrowArgumentNullException()
        {
            //Arrange
            var stack = new Stack<string>();
                       
            //Act & Arrange
            Assert.That(() => stack.Push(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Push_ValidArg_AddTheObjectToTheStack()
        {
            var stack = new Stack<string>();
            
            stack.Push("a");
            
            Assert.That(stack.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void Push_EmptyStack_ReturnZero()
        {
            var stack = new Stack<string>();

            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();
            
            Assert.That(() => stack.Pop(), Throws.Exception.TypeOf<InvalidOperationException>());
        }
        
        [Test]
        public void Pop_StackWithFewObject_ReturnObjectOnTheTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Pop();

            Assert.That(result == "c");
        }
        
        [Test]
        public void Pop_StackWithFewObject_RemoveObjectOnTheTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Pop();

            Assert.That(stack.Count == 2);
        }
        
        [Test]
        public void Peak_StackIsEmpty_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();
            
            Assert.That(()=>stack.Peek(), Throws.Exception.TypeOf<InvalidOperationException>());
        }
        
        [Test]
        public void Peak_StackWithObjects_ReturnObjectOnTheTop()
        {
            var stack = new Stack<string>();
    
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Peek();
            
            Assert.That(result, Is.EqualTo("c"));
        }
        
        [Test]
        public void Peek_StackWithObjects_DoesNotRemoveTheObjectOnTopOfTheStack()
        {
            var stack = new Stack<string>();
            
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            stack.Peek();
            
            Assert.That(stack.Count, Is.EqualTo(3));
        }
    }
}