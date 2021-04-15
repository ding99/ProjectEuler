﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode.Leet11_20 {

	internal class Node {
		internal int value;
		internal Node next;

		public Node(int d) {
			value = d;
			next = null;
		}
	}

	public class RemoveNode {
		public void Start() {
			Action(new int[] { 1, 2, 3, 4, 5}, 2);
			Action(new int[] { 1 }, 1);
			Action(new int[] { 1, 2 }, 1);
		}

		private void Action(int[] array, int n) {
			int size = Display(array, "nums");
			Console.WriteLine($", n = {n}");

			int[] result = new int[0];
			if (size >= n) {
				Node head = null, curt = null, next = null;
				for (int i = 0; i < size; i++) {
					next = new Node(array[i]);
					if (curt == null) head = next;
					else curt.next = next;
					curt = next;
				}

				int count = 0;
				for (curt = head; curt != null; curt = curt.next)
					count++;
				Console.WriteLine($"count 1 [{count}]");
				for (curt = head; curt != null; curt = curt.next)
					Console.Write(curt.value + " ");
				Console.WriteLine();

				next = null;
				for (curt = head; curt != null; next = curt, curt = curt.next) {
					if(count-- == n) {
						Console.WriteLine($"found: {curt.value} count {count}");
						if (next == null)
							head = curt.next;
						else
							next.next = curt.next;
						break;
					}
				}

				count = 0;
				for (curt = head; curt != null; curt = curt.next)
					count++;
				Console.WriteLine($"count 2 [{count}]");
				for (curt = head; curt != null; curt = curt.next)
					Console.Write(curt.value + " ");
				Console.WriteLine();

				List<int> values = new List<int>();
				for (curt = head; curt != null; curt = curt.next)
					values.Add(curt.value);

				result = values.ToArray();
			}

			Display(result, string.Empty);
			Console.WriteLine();
		}

		private int Display(int[] nums, string name) {
			int n = nums.Length;
			Console.Write($"{(string.IsNullOrEmpty(name) ? "Out" : "In")}put: {name}{(string.IsNullOrEmpty(name) ? "" : " = ")}[");
			for (int i = 0; i < n; i++) Console.Write($"{nums[i]}{(i + 1 == n ? "" : ",")}");
			Console.Write("]");
			return n;
		}
	}
}
