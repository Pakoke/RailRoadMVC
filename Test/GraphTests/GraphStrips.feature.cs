﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace GraphTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class GraphStripsFeatureFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GraphStrips.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GraphStripsFeature", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "GraphStripsFeature")))
            {
                GraphTests.GraphStripsFeatureFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find number of strips with maximum 3 stops")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GraphStripsFeature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CalculateNumberOfStrips")]
        public virtual void FindNumberOfStripsWithMaximum3Stops()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Find number of strips with maximum 3 stops", new string[] {
                        "CalculateNumberOfStrips"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Vertex Source",
                        "Vertex Target",
                        "Distance"});
            table1.AddRow(new string[] {
                        "A",
                        "B",
                        "5"});
            table1.AddRow(new string[] {
                        "B",
                        "C",
                        "4"});
            table1.AddRow(new string[] {
                        "C",
                        "D",
                        "8"});
            table1.AddRow(new string[] {
                        "D",
                        "C",
                        "8"});
            table1.AddRow(new string[] {
                        "D",
                        "E",
                        "6"});
            table1.AddRow(new string[] {
                        "A",
                        "D",
                        "5"});
            table1.AddRow(new string[] {
                        "C",
                        "E",
                        "2"});
            table1.AddRow(new string[] {
                        "E",
                        "B",
                        "3"});
            table1.AddRow(new string[] {
                        "A",
                        "E",
                        "7"});
#line 8
 testRunner.Given("the graph \"GraphToCalculate\" and the distances", ((string)(null)), table1, "Given ");
#line 19
 testRunner.When("find between city \"C\" and city \"C\" in the graph \"GraphToCalculate\" a maximum \"3\" " +
                    "stops", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then("the stops calculate is \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find number of strips exactly 4 stops")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GraphStripsFeature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CalculateNumberOfStrips")]
        public virtual void FindNumberOfStripsExactly4Stops()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Find number of strips exactly 4 stops", new string[] {
                        "CalculateNumberOfStrips"});
#line 23
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Vertex Source",
                        "Vertex Target",
                        "Distance"});
            table2.AddRow(new string[] {
                        "A",
                        "B",
                        "5"});
            table2.AddRow(new string[] {
                        "B",
                        "C",
                        "4"});
            table2.AddRow(new string[] {
                        "C",
                        "D",
                        "8"});
            table2.AddRow(new string[] {
                        "D",
                        "C",
                        "8"});
            table2.AddRow(new string[] {
                        "D",
                        "E",
                        "6"});
            table2.AddRow(new string[] {
                        "A",
                        "D",
                        "5"});
            table2.AddRow(new string[] {
                        "C",
                        "E",
                        "2"});
            table2.AddRow(new string[] {
                        "E",
                        "B",
                        "3"});
            table2.AddRow(new string[] {
                        "A",
                        "E",
                        "7"});
#line 24
 testRunner.Given("the graph \"GraphToCalculate\" and the distances", ((string)(null)), table2, "Given ");
#line 35
 testRunner.When("find between city \"A\" and city \"C\" in the graph \"GraphToCalculate\" a exactly \"4\" " +
                    "stops", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.Then("the stops calculate is \"3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
