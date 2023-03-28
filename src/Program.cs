﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ctrl_06
{
  class Program
  {
    static long Consommation(string titre, long précédent)
    {
      var mem = GC.GetAllocatedBytesForCurrentThread();

      Console.WriteLine($"{titre} : {(mem - précédent) / 1024}ko");
      return mem;
    }
    static void Main(string[] args)
    {
      var mem = GC.GetAllocatedBytesForCurrentThread();
      string s = "";
      for (int i = 0; i < 10000; i++)
      {
        s += i.ToString();
      }
      mem = Consommation("Concaténation chaînes", mem);

      StringBuilder sb = new();
      for (int i = 0; i < 10000; i++)
      {
        sb.Append(i);
      }
      mem = Consommation("Concaténation StringBuilder", mem);

      var t1 = new int[10000];
      for (int i = 0; i < 10000; i++)
      {
        t1[i] = i * 2;
      }

      var t2 = new List<int>();
      for (int i = 0; i < 10000; i++)
      {
        t2.Add(i * 2);
      }

      var t3 = new List<int>(10000);
      for (int i = 0; i < 10000; i++)
      {
        t3.Add(i * 2);
      }

      var liste = GetListe(10000);

      var liste2 = GetListeYield(10000);

      Span<int> t = stackalloc int[1000];
      for (int i = 0; i < 1000; i++)
      {
        t[i] = i * 2;
      }
    }

    static IEnumerable<int> GetListe(int taille)
    {
      var res = new List<int>(10000);
      for (int i = 0; i < 10000; i++)
      {
        res.Add(i * 2);
      }
      return res;
    }
    static IEnumerable<int> GetListeYield(int taille)
    {
      for (int i = 0; i < 10000; i++)
      {
        yield return i * 2;
      }
    }
  }
}
