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
			
			for (var i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] > 0) break;
                if (i != 0 && nums[i] == nums[i - 1]) continue;
                for (var k = nums.Length - 1; k > i + 1; k--)
                {
                    if (nums[k] < 0) break;
                    if (k != nums.Length - 1 && nums[k] == nums[k + 1]) continue;

                    var j = BinarySearch(-nums[i] - nums[k], nums, i + 1, k - 1);
                    if (j > -1)
                        list.Add(new[] {nums[i], nums[j], nums[k]});
                }
            }
            return list;
		}

		private int BinarySearch(int target, int[] nums, int min, int max)
        {
            if (target < nums[min] || target > nums[max]) return -1;
            while (min <= max)
            {
                var mid = (min + max)/2;
                if (target < nums[mid]) max = mid - 1;
                else if (target > nums[mid]) min = mid + 1;
                else return mid;
            }
            return -1;
        }
	}
}