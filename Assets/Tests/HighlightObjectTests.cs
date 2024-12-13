using NUnit.Framework;
using UnityEngine;

public class HighlightObjectTests
{
    private HighlightObject highlightObject;
    private GameObject testObj1;
    private GameObject testObj2;

    [SetUp]
    public void Setup()
    {
        highlightObject = new HighlightObject(Color.red);

        testObj1 = new GameObject();
        var renderer1 = testObj1.AddComponent<MeshRenderer>();
        //We'll need to use sharedMaterial for testing
        renderer1.sharedMaterial = new Material(Shader.Find("Standard"));

        testObj2 = new GameObject();
        var renderer2 = testObj2.AddComponent<MeshRenderer>();
        renderer2.sharedMaterial = new Material(Shader.Find("Standard"));
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(testObj1);
        Object.DestroyImmediate(testObj2);
    }

    //Testing that the highlight color was applied correctly
    [Test]
    public void ApplyHighlightColor()
    {
        highlightObject.UpdateHighlights(testObj1);

        var renderer = testObj1.GetComponent<Renderer>();
        Assert.AreEqual(Color.red, renderer.sharedMaterial.color);
    }

    //Testing to make sure an object's color is restored when we're done highlighting
    [Test]
    public void RestoreOriginalColor()
    {
        var renderer = testObj1.GetComponent<Renderer>();
        renderer.sharedMaterial.color = Color.green;

        highlightObject.UpdateHighlights(testObj1);

        Assert.AreEqual(Color.red, renderer.sharedMaterial.color);

        highlightObject.RemoveHighlights();

        Assert.AreEqual(Color.green, renderer.sharedMaterial.color);
    }

    //Testing a different object being highlighted when we update what to highlight
    //Also testing that we restore the original color of the first object
    [Test]
    public void ChangeObject()
    {
        var renderer1 = testObj1.GetComponent<Renderer>();
        var renderer2 = testObj2.GetComponent<Renderer>();
        renderer1.sharedMaterial.color = Color.green;
        renderer2.sharedMaterial.color = Color.blue;

        highlightObject.UpdateHighlights(testObj1);
        highlightObject.UpdateHighlights(testObj2);

        Assert.AreEqual(Color.green, renderer1.sharedMaterial.color);
        Assert.AreEqual(Color.red, renderer2.sharedMaterial.color); //should be red once we pass it into our highlighter
    }

    //Testing our IsDifferentObject function
    [Test]
    public void CheckIsDifferentObject()
    {
        highlightObject.UpdateHighlights(testObj1);
        bool isDifferent = highlightObject.isDifferentObject(testObj2);

        Assert.IsTrue(isDifferent);
    }

    //Testing IsDifferentObject on the same object
    [Test]
    public void IsDifferentObject_ReturnsFalseForSameObject()
    {
        highlightObject.UpdateHighlights(testObj1);
        bool isDifferent = highlightObject.isDifferentObject(testObj1);

        Assert.IsFalse(isDifferent);
    }
}
