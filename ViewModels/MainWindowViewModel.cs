using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Controls;

namespace CreacionClave.ViewModels;

public partial class MainWindowViewModel : INotifyPropertyChanged
{
    
    public string UltimaClaveGenerada { get; set; }
    public void cmdCrear(object listbox)
    {
        string claveGenerada = GenerarClave();
        UltimaClaveGenerada = claveGenerada;
        OnPropertyChanged(nameof(UltimaClaveGenerada));
        ((ListBox)listbox).Items.Add(UltimaClaveGenerada);
    }

    private string GenerarClave()
    {
        int longitud = new Random().Next(6, 13); //longitud de la cadena
        int numMayusculas = new Random().Next(longitud - 2);
        int numMinusculas = new Random().Next(longitud - numMayusculas - 1);
        int numNumeros = longitud - numMayusculas - numMinusculas;
        string clave = ""; 
        for (int i = 0; i < numMayusculas; i++)
        {
            clave += ((char)new Random().Next((int)'A', (int)'Z')).ToString();
        }

        for (int i = 0; i < numMinusculas; i++)
        {
            clave += ((char)new Random().Next((int)'a', (int)'z')).ToString();
        }

        for (int i = 0; i < numNumeros; i++)
        {
            clave += new Random().Next(10).ToString();
        }

        return clave;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}