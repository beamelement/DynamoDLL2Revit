using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Dynamo.Applications;

namespace Dynamo2Revit
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        Result IExternalCommand.Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            string Journal_Dynamo_Path = null ;  //一个空的dynamo文件

            //新建一个窗口
            Window1 window1 = new Window1();

            if (window1.ShowDialog() == true)
            {
                //窗口打开并停留，只有点击按键之后，窗口关闭并返回true
            }


            //按键会改变window的属性，通过对属性的循环判断来实现对按键的监测
            while (!window1.Done)
            {
                //选择一个空的dynamo文件
                if (window1.selected)
                {

                    //把选择进来的文件的路径输出一下
                    Journal_Dynamo_Path =  window1.fileName;



                }

                if (window1.ShowDialog() == true)
                {
                    //窗口打开并停留，只有点击按键之后，窗口关闭并返回true
                }

            }

            //开启Dynamo但是禁止弹出Dynamo对话框
            DynamoRevit dynamoRevit = new DynamoRevit();

            DynamoRevitCommandData dynamoRevitCommandData = new DynamoRevitCommandData();
            dynamoRevitCommandData.Application = commandData.Application;
            IDictionary<string, string> journalData = new Dictionary<string, string>
            {
                { Dynamo.Applications.JournalKeys.ShowUiKey, false.ToString() }, // don't show DynamoUI at runtime
                { Dynamo.Applications.JournalKeys.AutomationModeKey, true.ToString() }, //run journal automatically
                { Dynamo.Applications.JournalKeys.DynPathKey, Journal_Dynamo_Path }, //run node at this file path
                { Dynamo.Applications.JournalKeys.DynPathExecuteKey, true.ToString() }, // The journal file can specify if the Dynamo workspace opened from DynPathKey will be executed or not. If we are in automation mode the workspace will be executed regardless of this key.
                { Dynamo.Applications.JournalKeys.ForceManualRunKey, false.ToString() }, // don't run in manual mode
                { Dynamo.Applications.JournalKeys.ModelShutDownKey, true.ToString() }

            };

            dynamoRevitCommandData.JournalData = journalData;
            Result externalCommandResult = dynamoRevit.ExecuteCommand(dynamoRevitCommandData);
            return externalCommandResult;

        }
    }
}
