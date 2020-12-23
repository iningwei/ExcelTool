using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace ZGame.ZTable{
	public class t_subgame_vipReader{
		private t_subgame_vip[] entities;
		private Dictionary<int,int> keyIndexMap = new Dictionary<int,int>();

		private int count;
		 public int Count{
			get{ return this.count;}
		}

		static t_subgame_vipReader instance=null;
		public static t_subgame_vipReader Instance{
			get{
				if(instance==null){
					instance=new t_subgame_vipReader();
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
				entities=new t_subgame_vip[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new t_subgame_vip();
					entities[i].t_id=int.Parse(vals[0].Trim());
					entities[i].subgame_id=int.Parse(vals[1].Trim());
					entities[i].name=vals[2];
					entities[i].shown_name=vals[3];
					entities[i].ui_package_name=vals[4];
					entities[i].window_name=vals[5];
					entities[i].spin_order_name=vals[6];
					entities[i].hall_room_slot_icon=vals[7];
					entities[i].has_jackpot=bool.Parse(vals[8].Trim());
					entities[i].jackpot_shown_icon=vals[9];
					entities[i].eff_hall_slot_light=int.Parse(vals[10].Trim());
					entities[i].eff_hall_slot_button=int.Parse(vals[11].Trim());
					entities[i].eff_hall_slot_flash=int.Parse(vals[12].Trim());
					entities[i].showcase_icon=vals[13];
					entities[i].axes_count=int.Parse(vals[14].Trim());
					entities[i].is_updating=bool.Parse(vals[15].Trim());
					entities[i].des=vals[16];
					keyIndexMap[entities[i].t_id]=i;
				}
			};

			string fileName=t_subgame_vip.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// get datas of a row by Index
		/// index starts form 0,which marching the line 7 of excel table
		/// </summary>
		public t_subgame_vip GetEntityByRowIndex(int index){
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
		public t_subgame_vip GetEntityByPrimaryKey(int key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(t_subgame_vip);
			}
		}
		/// <summary>
		/// get all row datas
		/// </summary>
		public t_subgame_vip[] AllItems(){
			return this.entities;
		}
	}
}