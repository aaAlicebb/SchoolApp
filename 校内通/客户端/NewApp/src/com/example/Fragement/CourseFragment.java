package com.example.Fragement;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import android.graphics.Color;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.example.bean.CourseBean;
import com.example.newapp.R;
import com.example.util.DateUtil;
import com.example.util.DimenUtil;
import com.inqbarna.tablefixheaders.TableFixHeaders;
import com.inqbarna.tablefixheaders.adapters.BaseTableAdapter;
import com.lidroid.xutils.util.LogUtils;
import com.lidroid.xutils.view.annotation.ViewInject;

public class CourseFragment extends BaseFragment {

	@ViewInject(R.id.table)
	TableFixHeaders table;

	CourseTableAdapter tableAdapter;
	List<List<CourseBean>> mDatas=new ArrayList<List<CourseBean>>();
	List<CourseBean> courseBean=new ArrayList<CourseBean>();

	@Override
	public View initView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		return inflater.inflate(R.layout.fragment_course_list, null);
	}

	@Override
	protected void initData() {
		super.initData();
		
		CourseBean  course=new CourseBean();
		course.setCourseName("C语言程序设计");
		course.setDay(1);
		Date date=new Date();
		course.setEndTime(new Timestamp(
				System.currentTimeMillis()));
		course.setGradeName("大四");
		course.setStartTime(new Timestamp(
				System.currentTimeMillis()));
		course.setTeacherName("小明");
		course.setTeacherId(2);
		course.setGradeId(2);
		course.setCourseTableId(2);
		Log.i("gj",course.getCourseName());
		Log.i("gj",course.getGradeName());
		Log.i("gj",course.getTeacherName());
		Log.i("gj",course.getCourseTableId().toString());
		Log.i("gj",course.getDay().toString());
		Log.i("gj",course.getEndTime().toString());
		Log.i("gj",course.getGradeId().toString());
		Log.i("gj",course.getStartTime().toString());
		Log.i("gj",course.getTeacherId().toString());
		courseBean.add(course);
		mDatas.add(courseBean);
		tableAdapter = new CourseTableAdapter();
		table.setAdapter(tableAdapter);
//		CourseListReqBean bean = new CourseListReqBean();
//		bean.setGradeId(childInfo.getGradeBean().getGradeId());
//		HttpUtil.post(URL.COURSE_TABLE, bean,
//				new HttpBeanCallBack<CourseTableResBean>() {
//
//					@Override
//					public void onFailure(int statusCode, String errorMsg) {
//						hideLoadingView();
//					}
//
//					@Override
//					public void onSuccess(int statusCode, Header[] headers,
//							CourseTableResBean responseBean) {
//						hideLoadingView();
//						mDatas = responseBean.getCourses();
//						tableAdapter = new CourseTableAdapter();
//						table.setAdapter(tableAdapter);
//					}
//				});
	}

	class ColumnHeader {
		public String desc;
		public String time;
	}

	static final String[] rowHeaders = { "时间", "星期一", "星期二", "星期三", "星期四",
			"星期五" };

	class CourseTableAdapter extends BaseTableAdapter {

		ColumnHeader[] columnHeaders = new ColumnHeader[9];

		public CourseTableAdapter() {

			for (int i = 0; i < columnHeaders.length; i++) {
				CourseBean bean;
				switch (i) {
				case 0:
				case 5:
					columnHeaders[i] = null;
					break;
				case 1:
					bean = mDatas.get(0).get(0);
					columnHeaders[i] = new ColumnHeader();
					fillColumnData(columnHeaders[i], bean);
					columnHeaders[i].desc = "第一节课";
					break;
				case 2:
					bean = mDatas.get(0).get(0);
					columnHeaders[i] = new ColumnHeader();
					fillColumnData(columnHeaders[i], bean);
					columnHeaders[i].desc = "第二节课";
					break;
				case 3:
					bean = mDatas.get(0).get(0);
					columnHeaders[i] = new ColumnHeader();
					fillColumnData(columnHeaders[i], bean);
					columnHeaders[i].desc = "第三节课";
					break;
				case 4:
					bean = mDatas.get(0).get(0);
					columnHeaders[i] = new ColumnHeader();
					fillColumnData(columnHeaders[i], bean);
					columnHeaders[i].desc = "第四节课";
					break;
				case 6:
					bean = mDatas.get(0).get(0);
					columnHeaders[i] = new ColumnHeader();
					fillColumnData(columnHeaders[i], bean);
					columnHeaders[i].desc = "第五节课";
					break;
				case 7:
					bean = mDatas.get(0).get(0);
					columnHeaders[i] = new ColumnHeader();
					fillColumnData(columnHeaders[i], bean);
					columnHeaders[i].desc = "第六节课";
					break;
				case 8:
					bean = mDatas.get(0).get(0);
					columnHeaders[i] = new ColumnHeader();
					fillColumnData(columnHeaders[i], bean);
					columnHeaders[i].desc = "第七节课";
					break;

				}
			}
		}

		void fillColumnData(ColumnHeader header, CourseBean bean) {
			
			String start = DateUtil.getHHmmDateStr(new Date(bean.getStartTime()
					.getTime()));
			String end = DateUtil.getHHmmDateStr(new Date(bean.getEndTime()
					.getTime()));
			header.time = "(" + start + "—" + end + ")";
		}

		@Override
		public int getRowCount() {
			return 9;
		}

		@Override
		public int getColumnCount() {
			return rowHeaders.length-1;
		}

		@Override
		public View getView(int row, int column, View convertView,
				ViewGroup parent) {
			LogUtils.e("row_"+row+"---column_"+column+"--is get");
			View view = null;
			switch (getItemViewType(row, column)) {
			case 0:// 表头
				view = getRowHeader(row, column, convertView, parent);
				break;
			case 1:
				view = getColumnHeader(row, column, convertView, parent);
				break;
			case 2:
				view = getSubHeader(row, column, convertView, parent);
				break;
			case 3:
				view = getBody(row, column, convertView, parent);
				break;
			}
			
			return view;
		}

		private View getBody(int row, int column, View convertView,
				ViewGroup parent) {
			if (convertView == null) {
				convertView = View.inflate(context,
						R.layout.item_course_table_body, null);
			}

			convertView.setBackgroundColor((row+column) % 2 == 0 ? Color
					.parseColor("#ebf1a8") : Color.parseColor("#d5f0ff"));
			TextView lesson = (TextView) convertView.findViewById(R.id.lesson);
			TextView teacher = (TextView) convertView
					.findViewById(R.id.teacher);
			if (row < 5) {
				lesson.setText(mDatas.get(0).get(0)
						.getCourseName());
				teacher.setText("--"+mDatas.get(0).get(0)
						.getTeacherName()+"老师");
			} else {
				lesson.setText(mDatas.get(0).get(0)
						.getCourseName());
				teacher.setText("--"+mDatas.get(0).get(0)
						.getTeacherName()+"老师");
			}
			return convertView;
		}

		private View getSubHeader(int row, int column, View convertView,
				ViewGroup parent) {
			if (convertView == null) {
				convertView = View.inflate(context,
						R.layout.item_course_table_sub_header, null);
			}
			TextView tv = ((TextView) convertView.findViewById(R.id.text));
			if (row == 0 && column==-1) {
				tv.setText("--上午--");
			} else if (row == 5 && column==-1) {
				tv.setText("--下午--");
			}else{
				tv.setText("");
			}
			return convertView;
		}

		private View getColumnHeader(int row, int column, View convertView,
				ViewGroup parent) {
			if (convertView == null) {
				convertView = View.inflate(context,
						R.layout.item_course_table_column_header, null);
			}
			((TextView) convertView.findViewById(R.id.desc))
					.setText(columnHeaders[row].desc);
			((TextView) convertView.findViewById(R.id.time))
					.setText(columnHeaders[row].time);
//			if (row < 5) {
//				lesson.setText(mDatas.get(column + 1).get(row - 1)
//						.getCourseName());
//				teacher.setText(mDatas.get(column + 1).get(row - 1)
//						.getTeacherName());
//			} else {
//				lesson.setText(mDatas.get(column + 1).get(row - 2)
//						.getCourseName());
//				teacher.setText(mDatas.get(column + 1).get(row - 2)
//						.getTeacherName());
//			}
			return convertView;
		}

		private View getRowHeader(int row, int column, View convertView,
				ViewGroup parent) {
			if (convertView == null) {
				convertView = View.inflate(context,
						R.layout.item_course_table_row_header, null);
			}
			((TextView) convertView.findViewById(R.id.text))
					.setText(rowHeaders[column + 1]);
			return convertView;
		}

		@Override
		public int getWidth(int column) {
			return DimenUtil.dpToPx(120);
		}

		@Override
		public int getHeight(int row) {
			int height;
			if (row == -1)
				height = 36;
			else if (row == 0 || row == 5)//先隐藏列表头
				height = 0;
			else
				height = 48;
			return DimenUtil.dpToPx(height);
		}

		@Override
		public int getItemViewType(int row, int column) {
			final int itemViewType;
			if (row == -1) {// 行表头
				itemViewType = 0;
			}  else if (row == 0 || row == 5) {// 子表头 上午，下午
				itemViewType = 2;
			}else if (column == -1) {// 列表头
				itemViewType = 1;
				// TODO 先定死上午4节，下午3节课，有需要再动态改变
			} else
				itemViewType = 3; // 内容

			return itemViewType;
		}

		@Override
		public int getViewTypeCount() {
			return 4;
		}

	}

}
