using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ISP_MAUI.ViewModels;

public partial class CalculatorViewModel : BaseViewModel
{
    [ObservableProperty] private string _outputText = "0";

    private double _number;
    private double _input;
    private string _op = "=";

    private bool _calculated;

    private string[] _functions = {
        "√", "x^2", "1/x", "2^x", "%"
    };
    private string _digits = "0123456789.";
    
    [RelayCommand]
    public void OnClick(string command)
    {
        if (_functions.Contains(command))
        {
            CalculateFunc(command);
            _calculated = false;
        }
        else if (_digits.Contains(command))
        {
            InputDigit(command);
        }
        else if (command == "DEL")
        {
            Delete();
        }
        else if (command == "C")
        {
            Clear();
        }
        else if (command == "+/-")
        {
            SwitchSign();
        }
        else
        {
            if (!_calculated)
            {
                Calculate();
                _calculated = true;
            }

            _op = command;
        }
    }
    
    private void Calculate()
    {
        _input = Convert.ToDouble(OutputText, CultureInfo.InvariantCulture);
        switch (_op)
        {
            case "+":
                _number += _input;
                break;
            case "-":
                _number -= _input;
                break;
            case "X":
                _number *= _input;
                break;
            case "/":
                _number /= _input;
                break;
            case "=":
                _number = _input;
                break;
        }
        OutputText = Convert.ToString(_number, CultureInfo.InvariantCulture);
    }
    
    private void CalculateFunc(string op)
    {
        _input = Convert.ToDouble(OutputText, CultureInfo.InvariantCulture);
        switch (op)
        {
            case "x^2":
                _input = double.Pow(_input, 2);
                break;
            case "1/x":
                _input = 1 / _input;
                break;
            case "2^x":
                _input = double.Exp2(_input);
                break;
            case "√":
                _input = double.Sqrt(_input);
                break;
            case "%":
                _input /= 100;
                break;
        }

        OutputText = Convert.ToString(_input, CultureInfo.InvariantCulture);
    }
    
    public void InputDigit(string digit)
    {
        if (_calculated)
        {
            if (digit == ".")
                OutputText = "0.";
            else
                OutputText = digit;
            _calculated = false;
        }
        else if (OutputText == "0" && digit != ".")
            OutputText = digit;
        else
            OutputText += digit;
    }
    
    public void SwitchSign()
    {
        if (OutputText[0] == '-')
            OutputText = OutputText.Substring(1);
        else
            OutputText = "-" + OutputText;
    }
    
    public void Delete()
    {
        if (OutputText.Length == 1)
            OutputText = "0";
        else
            OutputText = OutputText.Substring(0, OutputText.Length - 1);
    }
    
    public void Clear()
    {
        OutputText = "0";
        _op = "=";
    }
}