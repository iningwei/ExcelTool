using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace SelfTable{
	public class GermSettingReader{
		private GermSetting[] entities;
		private Dictionary<int,int> keyIndexMap = new Dictionary<int,int>();

		private int count;
		 public int Count{
			get{ return this.count;}
		}

		static GermSetting_table instance=null;
		public static GermSetting_table Instance{
			get{
				if(instance==null){
					instance=new GermSetting_table();
					instance.Load();
				}
				return instance;
			}
		}

		void Load(){
			Action<string> onTableLoad=(text)=>{
				string[] lines=text.Split(new string[]{"\r\n"},System.StringSplitOptions.RemoveEmptyEntries);
				int count=lines.Length;
				if(count<0){
					return;
				}
				this.count = count;
				entities=new GermSetting[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new GermSetting();
					entities[i].ID=int.Parse(vals[0].Trim());
					entities[i].Name=vals[1];
					entities[i].PrefabName=vals[2];
					entities[i].Radius=float.Parse(vals[3].Trim());
					entities[i].MoveSpeed=float.Parse(vals[4].Trim());
					keyIndexMap[entities[i].ID]=i;
				}
			};

			string fileName=GermSetting.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// 根据Index获得具体某行数据
		/// index从0开始，和excel数据表中的行对应
		/// </summary>
		public GermSetting GetEntityByRowIndex(int index){
			if(index<0||index>count){
				Debug.LogError("index:"+index+" is not valid");
				return null;
			}
			else{
				return entities[index];
			}
		}
		/// <summary>
		/// 根据主键获得具体某行数据
		/// 需要确保主键不重复
		/// </summary>
		public GermSetting GetEntityByPrimaryKey(int key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(GermSetting);
			}
		}
		/// <summary>
		/// 获得所有数据项
		/// </summary>
		public GermSetting[] AllItems(){
			return this.entities;
		}
	}
}