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
    public partial class GraphFeatureFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GraphFeature.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GraphFeature", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "GraphFeature")))
            {
                GraphTests.GraphFeatureFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Calculate distance graph A-B-C")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GraphFeature")]
        public virtual void CalculateDistanceGraphA_B_C()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calculate distance graph A-B-C", ((string[])(null)));
#line 4
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
#line 5
 testRunner.Given("the graph \"GraphToCalculate\" and the distances", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Distances"});
            table2.AddRow(new string[] {
                        "A"});
            table2.AddRow(new string[] {
                        "B"});
            table2.AddRow(new string[] {
                        "C"});
#line 16
 testRunner.When("find the distance from the graph \"GraphToCalculate\"", ((string)(null)), table2, "When ");
#line 21
 testRunner.Then("the distance calculate is \"9\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Calculate distance graph A-D")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GraphFeature")]
        public virtual void CalculateDistanceGraphA_D()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calculate distance graph A-D", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Vertex Source",
                        "Vertex Target",
                        "Distance"});
            table3.AddRow(new string[] {
                        "A",
                        "B",
                        "5"});
            table3.AddRow(new string[] {
                        "B",
                        "C",
                        "4"});
            table3.AddRow(new string[] {
                        "C",
                        "D",
                        "8"});
            table3.AddRow(new string[] {
                        "D",
                        "C",
                        "8"});
            table3.AddRow(new string[] {
                        "D",
                        "E",
                        "6"});
            table3.AddRow(new string[] {
                        "A",
                        "D",
                        "5"});
            table3.AddRow(new string[] {
                        "C",
                        "E",
                        "2"});
            table3.AddRow(new string[] {
                        "E",
                        "B",
                        "3"});
            table3.AddRow(new string[] {
                        "A",
                        "E",
                        "7"});
#line 24
 testRunner.Given("the graph \"GraphToCalculate\" and the distances", ((string)(null)), table3, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Distances"});
            table4.AddRow(new string[] {
                        "A"});
            table4.AddRow(new string[] {
                        "D"});
#line 35
 testRunner.When("find the distance from the graph \"GraphToCalculate\"", ((string)(null)), table4, "When ");
#line 39
 testRunner.Then("the distance calculate is \"5\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Calculate distance graph A-D-C")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GraphFeature")]
        public virtual void CalculateDistanceGraphA_D_C()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calculate distance graph A-D-C", ((string[])(null)));
#line 41
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Vertex Source",
                        "Vertex Target",
                        "Distance"});
            table5.AddRow(new string[] {
                        "A",
                        "B",
                        "5"});
            table5.AddRow(new string[] {
                        "B",
                        "C",
                        "4"});
            table5.AddRow(new string[] {
                        "C",
                        "D",
                        "8"});
            table5.AddRow(new string[] {
                        "D",
                        "C",
                        "8"});
            table5.AddRow(new string[] {
                        "D",
                        "E",
                        "6"});
            table5.AddRow(new string[] {
                        "A",
                        "D",
                        "5"});
            table5.AddRow(new string[] {
                        "C",
                        "E",
                        "2"});
            table5.AddRow(new string[] {
                        "E",
                        "B",
                        "3"});
            table5.AddRow(new string[] {
                        "A",
                        "E",
                        "7"});
#line 42
 testRunner.Given("the graph \"GraphToCalculate\" and the distances", ((string)(null)), table5, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Distances"});
            table6.AddRow(new string[] {
                        "A"});
            table6.AddRow(new string[] {
                        "D"});
            table6.AddRow(new string[] {
                        "C"});
#line 53
 testRunner.When("find the distance from the graph \"GraphToCalculate\"", ((string)(null)), table6, "When ");
#line 58
 testRunner.Then("the distance calculate is \"13\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Calculate distance graph A-E-B-C-D")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GraphFeature")]
        public virtual void CalculateDistanceGraphA_E_B_C_D()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calculate distance graph A-E-B-C-D", ((string[])(null)));
#line 60
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Vertex Source",
                        "Vertex Target",
                        "Distance"});
            table7.AddRow(new string[] {
                        "A",
                        "B",
                        "5"});
            table7.AddRow(new string[] {
                        "B",
                        "C",
                        "4"});
            table7.AddRow(new string[] {
                        "C",
                        "D",
                        "8"});
            table7.AddRow(new string[] {
                        "D",
                        "C",
                        "8"});
            table7.AddRow(new string[] {
                        "D",
                        "E",
                        "6"});
            table7.AddRow(new string[] {
                        "A",
                        "D",
                        "5"});
            table7.AddRow(new string[] {
                        "C",
                        "E",
                        "2"});
            table7.AddRow(new string[] {
                        "E",
                        "B",
                        "3"});
            table7.AddRow(new string[] {
                        "A",
                        "E",
                        "7"});
#line 61
 testRunner.Given("the graph \"GraphToCalculate\" and the distances", ((string)(null)), table7, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Distances"});
            table8.AddRow(new string[] {
                        "A"});
            table8.AddRow(new string[] {
                        "E"});
            table8.AddRow(new string[] {
                        "B"});
            table8.AddRow(new string[] {
                        "C"});
            table8.AddRow(new string[] {
                        "D"});
#line 72
 testRunner.When("find the distance from the graph \"GraphToCalculate\"", ((string)(null)), table8, "When ");
#line 79
 testRunner.Then("the distance calculate is \"22\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Calculate distance graph A-E-D")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GraphFeature")]
        public virtual void CalculateDistanceGraphA_E_D()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calculate distance graph A-E-D", ((string[])(null)));
#line 81
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Vertex Source",
                        "Vertex Target",
                        "Distance"});
            table9.AddRow(new string[] {
                        "A",
                        "B",
                        "5"});
            table9.AddRow(new string[] {
                        "B",
                        "C",
                        "4"});
            table9.AddRow(new string[] {
                        "C",
                        "D",
                        "8"});
            table9.AddRow(new string[] {
                        "D",
                        "C",
                        "8"});
            table9.AddRow(new string[] {
                        "D",
                        "E",
                        "6"});
            table9.AddRow(new string[] {
                        "A",
                        "D",
                        "5"});
            table9.AddRow(new string[] {
                        "C",
                        "E",
                        "2"});
            table9.AddRow(new string[] {
                        "E",
                        "B",
                        "3"});
            table9.AddRow(new string[] {
                        "A",
                        "E",
                        "7"});
#line 82
 testRunner.Given("the graph \"GraphToCalculate\" and the distances", ((string)(null)), table9, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Distances"});
            table10.AddRow(new string[] {
                        "A"});
            table10.AddRow(new string[] {
                        "E"});
            table10.AddRow(new string[] {
                        "D"});
#line 93
 testRunner.When("find the distance from the graph \"GraphToCalculate\"", ((string)(null)), table10, "When ");
#line 98
 testRunner.Then("the distance calculate is \"null\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
