﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.ViewModels
{
    public partial class CientificaViewModel : ObservableObject

    {
        [ObservableProperty]
        private string inputText = "";

        [ObservableProperty]
        private string calculatedResult = "0";

        private bool isSciOpWaiting = false;        

        [RelayCommand]
        private void Reset()
        {
            CalculatedResult = "0";
            InputText = "";
            isSciOpWaiting = false;
        }

        [RelayCommand]
        private void Calculate()
        {
            if (InputText.Length == 0)
                return;

            if (isSciOpWaiting)
            {
                InputText += ")";
                isSciOpWaiting = false;
            }

            try
            {
                var inputString = NormalizeInputString();
                //var expression = new Expression(inputString);
                //var result = expression.Evaluate();
                var result = EvaluarExpresion(inputString);
                CalculatedResult = result.ToString();
            }
            catch (Exception ex)
            {
                CalculatedResult = "NaN";
            }
        }

        public static double EvaluarExpresion(string expresion)
        {
            try
            {
                return Convert.ToDouble(new System.Data.DataTable().Compute(expresion.Replace('X', '*'), ""));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al evaluar la expresión: " + ex.Message);
                return 0;
            }
        }

        private string NormalizeInputString()
        {
            Dictionary<string, string> _opMapper = new()
        {
            {"×", "*"},
            {"÷", "/"},
            {"SIN", "Sin"},
            {"COS", "Cos"},
            {"TAN", "Tan"},
            {"ASIN", "Asin"},
            {"ACOS", "Acos"},
            {"ATAN", "Atan"},
            {"LOG", "Log"},
            {"EXP", "Exp"},
            {"LOG10", "Log10"},
            {"POW", "Pow"},
            {"SQRT", "Sqrt"},
            {"ABS", "Abs"},
        };

            var retString = InputText;

            foreach (var key in _opMapper.Keys)
            {
                retString = retString.Replace(key, _opMapper[key]);
            }

            return retString;
        }

        [RelayCommand]
        private void Backspace()
        {
            if (InputText.Length > 0)
                InputText = InputText.Substring(0, InputText.Length - 1);
        }

        [RelayCommand]
        private void NumberInput(string key)
        {
            InputText += key;
        }

        [RelayCommand]
        private void MathOperator(string op)
        {
            if (isSciOpWaiting)
            {
                InputText += ")";
                isSciOpWaiting = false;
            }

            InputText += $" {op} ";
        }

        [RelayCommand]
        private void RegionOperator(string op)
        {
            if (op == ")")
                isSciOpWaiting = false;

            InputText += op;
        }

        [RelayCommand]
        private void ScientificOperator(string op)
        {
            InputText += $"{op}(";
            isSciOpWaiting = true;
        }

    }
}
