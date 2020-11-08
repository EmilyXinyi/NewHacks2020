using AwesomeCharts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Program : MonoBehaviour
{
    public TMPro.TMP_Text title;
    public TMPro.TMP_Text messageText;

    public Button End;
    public Button ChangeView;

    public GameObject lineChartGo;
    public GameObject pieChartGo;
    public GameObject barChartGo;

    public PieChart pieChart;
    public LineChart lineChart;
    public BarChart barChart;

    int chartIndex = 0;

    void Start()
    {
        createTitle();
        End.onClick.AddListener(delegate { end(); });
        ChangeView.onClick.AddListener(delegate { changeView(); });
    }
    void createTitle()
    {
        string date = DateTime.Today.ToString();
        title.text = date;
    }

    //just end the current video, save the results, and return to the home page

    //ok, so in the home page, just add the past video stuff, and then it will be fine 
    // just 

    void end()
    {
        writeInfo();
        SceneManager.LoadScene("Home");
    }

    //every few timesteps, this will write the current info into an xml or csv
    void writeInfo()
    {

    }

    //cycle the graph view, and update the graph accordingly 
    void changeView()
    {
        chartIndex++;
        if(chartIndex >= 3)
        {
            chartIndex = 0;
        }
        switch (chartIndex)
        {
            case 0:
                pieChartGo.SetActive(true);
                lineChartGo.SetActive(false);
                barChartGo.SetActive(false);
                break;
            case 1:
                pieChartGo.SetActive(false);
                lineChartGo.SetActive(false);
                barChartGo.SetActive(true);
                break;
            case 2:
                pieChartGo.SetActive(false);
                lineChartGo.SetActive(true);
                barChartGo.SetActive(false);
                break;
        }
        updateChart();
    }

    void updateChart()
    {
        switch (chartIndex)
        {
            case 0:
                updatePieChart();
                break;
            case 1:
                updateBarChart();
                break;
            case 2:
                updateLineChart();
                break;
            default:
                showError();
                break;
        }
    }

    //confused, distracted, engaged
    float confused = 0, distracted = 0, engaged = 0;
    PieDataSet set = new PieDataSet();
    void updatePieChart()
    {
        var dataset = pieChart.GetChartData().DataSet;
        dataset.Entries[0].Value = confused;
        dataset.Entries[1].Value = distracted;
        dataset.Entries[2].Value = engaged;

        pieChart.SetDirty();
    }
    void updateBarChart()
    {
        var dataset = barChart.GetChartData().DataSets[0];
        dataset.Entries[0].Value = confused;
        dataset.Entries[1].Value = distracted;
        dataset.Entries[2].Value = engaged;
        barChart.SetDirty();
    }

    void updateLineChart()
    {
        var dataset = lineChart.GetChartData().DataSets[0];
        dataset.Entries[0].Value = confused;
        dataset.Entries[1].Value = distracted;
        dataset.Entries[2].Value = engaged;
        lineChart.SetDirty();
    }

    void showError()
    {
        messageText.text = "There was an error, please end the stream, and restart it.";
    }

    float fps = 30;
    int index = 0;
    //this will update the graphs, whenever the thing is called 
    void Update()
    {
        index++;
        if(index % fps == 0)
        {
            index = 0;
            callMatLab();
            updateChart();
        }  
    }

    //this will call the matlab executable, and get the output 
    void callMatLab()
    {
        //here set confused, distracted and engaged

    }

}
