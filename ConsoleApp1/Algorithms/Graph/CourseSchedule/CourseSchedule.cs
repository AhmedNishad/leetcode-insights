using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Algorithms.Graph.CourseSchedule
{
    public class CourseSchedule
    {
        public static void Test()
        {
            var arr = new int[][] { new int[]{ 0, 1 }, new int[] { 0, 2}, new int[] { 1, 3 }, new int[] { 1, 4 }, new int[] { 3, 4 } };
            var failArr = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 } };
            var result =  CanFinish(5, arr);
           // result = CanFinish(3, failArr);
        }

        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // map each course to a list of prerequisitions
            Dictionary<int, List<int>> preMap = new Dictionary<int, List<int>>();
            for(int i = 0; i < numCourses; i++)
            {
                preMap[i] = new List<int>();
            }

            foreach (var p in prerequisites)
            {
                preMap[p[0]].Add(p[1]);
            }

            // Visit set for all the courses along the current Depth First Search Path
            HashSet<int> visitSet = new HashSet<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (!DFS(i, preMap, visitSet)) return false;
            }

            return true;
        }

        public static bool DFS(int course, Dictionary<int, List<int>> preMap, HashSet<int> visitSet)
        {
            // Already visited this path in the courses
            if (visitSet.Contains(course))
                return false;

            // No more prerequisites
            if (preMap[course].Count == 0)
                return true;

            visitSet.Add(course);
            foreach(var pre in preMap[course])
            {
                if (!DFS(pre, preMap, visitSet)) return false;
            }

            // this means there are no more prerequisites so we can remove from the visit set
            visitSet.Remove(course);
            // Makes sure that we don't repeat processing prerequisites if we enter from another path
            preMap[course] = new List<int> { };
            return true;
        }

        public static bool CanFinishNishad(int numCourses, int[][] prerequisites)
        {
            // we are using an adjacency list ds
            Dictionary<int, List<int>> al = new Dictionary<int, List<int>>();
            HashSet<int> hs = new HashSet<int>();

            foreach(var pre2D in prerequisites)
            {
                List<int> pres = null;
                if (!al.TryGetValue(pre2D[0], out pres))
                {
                    // the prerequisite course is yet to be finished
                    al.Add(pre2D[0], new List<int> { pre2D[1] });
                }
                else
                {
                    if (!pres.Contains(pre2D[1]))
                        pres.Add(pre2D[1]);
                }
                hs.Add(pre2D[0]);
            }

            foreach (var p in al.Values)
            {
                foreach(var i in p)
                {
                    if (hs.Contains(i))
                        return false;

                    List<int> pres = null;
                    // if no prerequisites for that course
                    if (!al.TryGetValue(i, out pres))
                        numCourses--;
                }
            }

            return numCourses >= 0;
        }
    }
}
