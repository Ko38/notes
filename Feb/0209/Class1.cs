using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeSum
{
	public class Solution
	{
		public IList<IList<int>> ThreeSum(int[] nums)
		{
			Array.Sort(nums);
			IList<IList<int>> list = new List<IList<int>>();

			//for (int i = 0; i < nums.Length-2; i++)
			//{
			//	if (nums[i] > 0) break;
			//	if (i!=0 && nums[i] == nums[i-1]) continue;
			//	for (int j = i +1; j < nums.Length-1; j++)
			//	{
			//		if (nums[j] == nums[j-1] && j>i+1) continue;
			//		if (nums[i] + nums[j] > 0) break;
			//		for (int k = nums.Length-1; k > j; k--)
			//		{
			//			if (nums[k] < 0) break;
			//			//if (k < nums.Length - 1 && (nums[k] == nums[k + 1])) continue;

			//			if (nums[i] + nums[j] + nums[k] < 0) break;
			//			if (nums[i]+ nums[j]+ nums[k] ==0)
			//			{
			//				list.Add(new[] { nums[i], nums[j], nums[k] });
			//				break;
			//			}
			//		}
			//	}
			//}

			for (int i = 0; i < nums.Length-2; i++)
			{
				if (nums[i] > 0) break;
				if (i!=0 && nums[i] == nums[i-1]) continue;
				for (int k = nums.Length-1; k > i+1; k--)
				{
					if (nums[k] < 0) break;
					if (k < nums.Length - 1 && (nums[k] == nums[k + 1])) continue;

					var j = binarySearch(i+1, k-1, nums, -nums[i]-nums[k]);

					if (j!=-1)
					{
						list.Add(new[] { nums[i], nums[j], nums[k] });
						break;
					}
				}
			}

			return list;
		}

		public int binarySearch(int min, int max, int[] nums, int target)
		{
			if (min > max) return -1;

			int mid = (min + max)/2;
			if (target > nums[mid])
				return binarySearch(mid + 1, max, nums, target);
			if (target < nums[mid])
				return binarySearch(min, mid-1, nums, target);

			return mid;
		}
	}
}