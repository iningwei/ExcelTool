using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace ZGame.ZTable{
	public class itemReader{
		private item[] entities;
		private Dictionary<int,int> keyIndexMap = new Dictionary<int,int>();

		private int count;
		 public int Count{
			get{ return this.count;}
		}

		static itemReader instance=null;
		public static itemReader Instance{
			get{
				if(instance==null){
					instance=new itemReader();
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
				entities=new item[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new item();
					entities[i].ID=int.Parse(vals[0].Trim());
					entities[i].durable=uint.Parse(vals[1].Trim());
					entities[i].type=int.Parse(vals[2].Trim());
					entities[i].kind=int.Parse(vals[3].Trim());
					entities[i].list=int.Parse(vals[4].Trim());
					entities[i].update=int.Parse(vals[5].Trim());
					entities[i].down=vals[6].Split(',').ToIntArray();
					entities[i].up=vals[7].Split(',').ToIntArray();
					entities[i].level=int.Parse(vals[8].Trim());
					entities[i].star=int.Parse(vals[9].Trim());
					entities[i].NFT=int.Parse(vals[10].Trim());
					entities[i].time=int.Parse(vals[11].Trim());
					entities[i].drop=int.Parse(vals[12].Trim());
					entities[i].merge=int.Parse(vals[13].Trim());
					entities[i].quanitityType=int.Parse(vals[14].Trim());
					entities[i].quanititylimit=int.Parse(vals[15].Trim());
					keyIndexMap[entities[i].ID]=i;
				}
			};

			string fileName=item.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// get datas of a row by Index
		/// index starts form 0,which marching the line 7 of excel table
		/// </summary>
		public item GetEntityByRowIndex(int index){
			if(index<0||index>count){
				Debug.LogError("index:"+index+" is not valid");
				return null;
			}
			else{
				return entities[index];
			}
		}
		/// <summary>
		/// get datas of a row by primary key
		/// </summary>
		public item GetEntityByPrimaryKey(int key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(item);
			}
		}
		/// <summary>
		/// get all row datas
		/// </summary>
		public item[] AllItems(){
			return this.entities;
		}
	}
}