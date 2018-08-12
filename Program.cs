using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace algoithms_sort_assignment
{
	class DataClass
	{
		//class model to get each set of data
		public int dataMonthID { get; set; }
		public int yearData { get; set; }
		public string monthData { get; set; }
		public int dayData { get; set; }
		public string timeData { get; set; }
		public double magData { get; set; }
		public double latData { get; set; }
		public double longData { get; set; }
		public double depthData { get; set; }
		public string regionData { get; set; }
		public int irisData { get; set; }
		public int timeStampData { get; set; }

		//display the collection of data 
		public override string ToString()
		{
			return yearData + "\t| " + monthData + "\t| " + dayData + "\t| " + timeData + "\t| " + magData + "\t| " + latData + "\t| " + longData + "\t| " + depthData + "\t| " +
				regionData + "\t\t\t| " + irisData + "\t| " + timeStampData;
		}
	}

	class sortingAlgorithms
	{
		//bubble sort algorithm
		public void BubbleSort(List<DataClass> data, int SortedData)
		{
			int length = data.Count;
			DataClass temp = data[0];
			bool IsLarger = false;
			for (int i = 0; i < length; i++)
			{
				for (int j = i + 1; j < length; j++)
				{
					//switch case depending on which data user chooses to be sorted (only sorts int values)
					switch (SortedData)
					{
						case 1:
							IsLarger = data[i].yearData > data[j].yearData;
							break;
						case 2:
							IsLarger = data[i].dataMonthID > data[j].dataMonthID;
							break;
						case 3:
							IsLarger = data[i].dayData > data[j].dayData;
							break;
						case 5:
							IsLarger = data[i].magData > data[j].magData;
							break;
						case 6:
							IsLarger = data[i].latData > data[j].latData;
							break;
						case 7:
							IsLarger = data[i].longData > data[j].longData;
							break;
						case 8:
							IsLarger = data[i].depthData > data[j].depthData;
							break;
						case 10:
							IsLarger = data[i].irisData > data[j].irisData;
							break;
						case 11:
							IsLarger = data[i].timeStampData > data[j].timeStampData;
							break;
					}

					if (IsLarger)
					{
						{
							temp = data[i];
							data[i] = data[j];
							data[j] = temp;
						}
					}
				}
			}
		}

		//quick sort to sort string values

		public void QuickSort(List<DataClass> data, int start, int end, int sortedData) 
		{
			int i = start;
			int j = end;
			IComparable pivot;

			switch (sortedData)
			{ 
				case 4:
					//sort time
					pivot = data[(start / end) / 2].timeData;

					while (i <= j)
					{
						while (data[i].timeData.CompareTo(pivot) < 0)
						{
							i++;
						}
						while (data[j].timeData.CompareTo(pivot) > 0)
						{
							j++;
						}

						//swap the data is left is less than right
						if (i <= j)
						{
							DataClass tempData = data[i];
							data[i] = data[j];
							data[j] = tempData;

							i++;
							j--;
						}
					}

					if (start < j)
					{
						//quicksort first half of data
						QuickSort(data, start, j, 4);
					}
					if (i < end)
					{
						//quicksort right half of data
						QuickSort(data, j, end, 4);
					}
					break;

				case 9:
					//sort region
					pivot = data[(start / end) / 2].regionData;

					while (i <= j)
					{
						while (data[i].regionData.CompareTo(pivot) < 0)
						{
							i++;
						}
						while (data[j].regionData.CompareTo(pivot) > 0)
						{
							j++;
						}

						//swap the data is left is less than right
						if (i <= j)
						{
							DataClass tempData = data[i];
							data[i] = data[j];
							data[j] = tempData;

							i++;
							j--;
						}
					}

					if (start<j)
					{
						//quicksort first half of data
						QuickSort(data, start, j, 4);
					}
					if (i<end)
					{
						//quicksort right half of data
						QuickSort(data, j, end, 4);
					}
					break;
			}
		}

		public void MonthSort(List<DataClass> data) 
		{

			//assign months ordered values
			Dictionary<string, int> Months = new Dictionary<string, int>(){ 
				{ "January ", 1 },
				{ "February ", 2 },
				{ "March ", 3 },
				{ "April ", 4 },
				{ "May", 5 },
				{ "June ", 6 },
				{ "July ", 7 },
				{ "August ", 8 },
				{ "September ", 9 },
				{ "October", 10 },
				{ "November", 11 },
				{ "December ", 12 }
				
			};

			for (int i = 0; i < data.Count; i++)
			{
				int MonthNumber;
				if (Months.ContainsKey(data[i].monthData))
				{
					//return integer from dictionary
					Months.TryGetValue(data[i].monthData, out MonthNumber);
					data[i].dataMonthID = MonthNumber;
				}
			}

			BubbleSort(data, 2);
		}
	}

	class searchingAlgorithms
	{
		//search integer values and double value
		public void BinarySearch(List<DataClass> data, double SearchInput, int SortedData)
		{
			bool ResultFound = false;

			int i = 0;
			int start = 0;
			int end = data.Count - 1;
			bool EqualToCheck = false;
			bool LessThanCheck = false;

			while (start <= end && i < data.Count)
			{
				int mid = (start + end) / 2;

				switch (SortedData)
				{
					case 1:
						EqualToCheck = SearchInput == data[mid].yearData;
						LessThanCheck = SearchInput < data[mid].yearData;
						break;
					case 3:
						EqualToCheck = SearchInput == data[mid].dayData;
						LessThanCheck = SearchInput < data[mid].dayData;
						break;
					case 5:
						EqualToCheck = SearchInput == data[mid].magData;
						LessThanCheck = SearchInput < data[mid].magData;
						break;
					case 6:
						EqualToCheck = SearchInput == data[mid].latData;
						LessThanCheck = SearchInput < data[mid].latData;
						break;
					case 7:
						EqualToCheck = SearchInput == data[mid].longData;
						LessThanCheck = SearchInput < data[mid].longData;
						break;
					case 8:
						EqualToCheck = SearchInput == data[mid].depthData;
						LessThanCheck = SearchInput < data[mid].depthData;
						break;
					case 10:
						EqualToCheck = SearchInput == data[mid].irisData;
						LessThanCheck = SearchInput < data[mid].irisData;
						break;
					case 11:
						EqualToCheck = SearchInput == data[mid].timeStampData;
						LessThanCheck = SearchInput < data[mid].timeStampData;
						break;		
				}

				if (EqualToCheck)
				{
					Console.WriteLine(data[mid]);
					ResultFound = true;
					start++;

				}

				//values in the bottom half
				else if (LessThanCheck)
				{
					end = mid - 1;
				}

				//values in the top half
				else
				{
					start = mid + 1;
				}
			}

			if (ResultFound == false)
				Console.WriteLine("No results found for " + SearchInput);
		}


		//search string values
		public void LinearSearch(List<DataClass> data, string searchInput)
		{
			bool ResultFound = false;

			for (int i = 0; i < data.Count; i++)
			{
				if (data[i].monthData == searchInput || data[i].regionData == searchInput || data[i].timeData == searchInput)
				{
					ResultFound = true;
					Console.WriteLine(data[i]);
				}
			}

			if (ResultFound == false)
				Console.WriteLine("No results for " + searchInput);
		}

	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			//sorting object
			sortingAlgorithms sortData = new sortingAlgorithms();

			//searching object
			searchingAlgorithms searchData = new searchingAlgorithms();

			string[] yearString = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Year_1.txt"));
			string[] dayString = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Day_1.txt"));
			string[] magString = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Magnitude_1.txt"));
			string[] latString = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Year_1.txt"));
			string[] longString = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Day_1.txt"));
			string[] depthString = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Magnitude_1.txt"));
			string[] irisString = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Day_1.txt"));
			string[] timeStampString = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "TimeStamp_1.txt"));

			//convert string files to double and int arrays
			int[] 	 yearInt      = yearString.Select(n => Convert.ToInt32(n)).ToArray();
			string[] monthString  = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Month_1.txt"));
			int[]	 dayInt       = dayString.Select(n => Convert.ToInt32(n)).ToArray();
			string[] timeString   = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Time_1.txt"));
			double[] magDouble    = magString.Select(n => Convert.ToDouble(n)).ToArray();
			double[] latDouble    = latString.Select(n => Convert.ToDouble(n)).ToArray();
			double[] longDouble   = longString.Select(n => Convert.ToDouble(n)).ToArray();
			double[] depthDouble  = depthString.Select(n => Convert.ToDouble(n)).ToArray();
			string[] regionString = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Region_1.txt"));
			int[] 	 irisInt      = irisString.Select(n => Convert.ToInt32(n)).ToArray();
			int[] 	 timeStampInt = timeStampString.Select(n => Convert.ToInt32(n)).ToArray();

			//list to contain all data
			List<DataClass> CollectedData = new List<DataClass>();

			//add each data collection to list
			for (int i = 0; i < yearInt.Length; i++)
			{
				CollectedData.Add(new DataClass()
				{
					yearData = yearInt[i],
					monthData = monthString[i],
					dayData = dayInt[i],
					timeData = timeString[i],
					magData = magDouble[i],
					latData = latDouble[i],
					longData = longDouble[i],
					depthData = depthDouble[i],
					regionData = regionString[i],
					irisData = irisInt[i],
					timeStampData = timeStampInt[i]
				});
			}

			foreach (DataClass d in CollectedData)
			{
				Console.WriteLine(d);
			}

			int SortDataInput = 0;
			bool AcceptInput = false;
			while (true)
			{
				do
				{
					Console.WriteLine("Which Data You Would Like To Sort:\n1. Year\n2. Month\n3. Day\n4. Time\n5.Magnitude\n6. Latitude\n7. Longitude\n8. Depth\n9. Region\n10. IRIS ID\n11. Time Stamp");

					try
					{
						SortDataInput = Convert.ToInt32(Console.ReadLine());
						AcceptInput = true;

						switch (SortDataInput)
						{
							case 1:
							case 3:
							case 10:
							case 11:
								//sort integers
								sortData.BubbleSort(CollectedData, SortDataInput);
								break;
							case 5:
							case 6:
							case 7:
							case 8:
								//sort doubles
								sortData.BubbleSort(CollectedData, SortDataInput);
								break;
							case 2:
								//sort months
								sortData.MonthSort(CollectedData);
								break;
							case 9:
							case 4:
								//sort strings
								sortData.QuickSort(CollectedData, 0, CollectedData.Count - 1, SortDataInput);
								break;
							default:
								Console.WriteLine("Invalid input, please enter one of the numbers above");
								AcceptInput = false;
								break;
						}
					}
					catch (Exception)
					{
						Console.WriteLine("Please enter a valid input");
					}

				} while (AcceptInput == false);

				AcceptInput = false;
				do
				{
					Console.WriteLine("What data would you like to display: \n1)Search Data\n2)Display All\n3)Max Value\n4)Min Value");

					try
					{
						int searchDataInput = Convert.ToInt32(Console.ReadLine());
						AcceptInput = true;

						switch (searchDataInput)
						{
							case 1:
								//search values
								Console.Write("Enter search value: ");
								string search = Console.ReadLine();
								if (SortDataInput != 2 && SortDataInput != 4 && SortDataInput != 9)
								{
									//binary search integer and double values
									double numSearch = Convert.ToDouble(search);
									searchData.BinarySearch(CollectedData, numSearch, SortDataInput);
								}
								else
								{
									//linear search strings
									searchData.LinearSearch(CollectedData, search);
								}
								break;
							case 2:
								//display all
								foreach (DataClass data in CollectedData)
									Console.WriteLine(data);
								break;
							case 3:
								//display max
								Console.WriteLine(CollectedData[CollectedData.Count - 1]);
								break;
							case 4:
								//display min
								Console.WriteLine(CollectedData[0]);
								break;
							default:
								Console.WriteLine("Please enter one of the numbers above");
								AcceptInput = false;
								break;
						}
					}
					catch (Exception)
					{
						Console.WriteLine("Please enter a valid integer");
					}
				} while (AcceptInput == false);

				try
				{
					Console.WriteLine("Restard program? 1.Yes 2.No");
					int userinput = Convert.ToInt32(Console.ReadLine());

					if (userinput == 1)
					{
						continue;
					}

					if (userinput == 2)
					{
						break;
					}
				}
				catch(FormatException)
				{
					Console.WriteLine("Please enter a valid input");
				}
			} 
		}
	}
}
