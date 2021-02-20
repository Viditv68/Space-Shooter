using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ScoreTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ScoreTests()
        {
            var uiManager = new GameObject().AddComponent<UIManager>();


            uiManager.updateScore();

            int expectScore = 10;

            Assert.AreEqual(uiManager.score, expectScore);



        }

        
    }
}
