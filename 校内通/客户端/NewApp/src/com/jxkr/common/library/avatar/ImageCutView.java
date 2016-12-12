package com.jxkr.common.library.avatar;

import android.annotation.SuppressLint;
import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.Bitmap.Config;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.PorterDuff;
import android.graphics.PorterDuffXfermode;
import android.graphics.Rect;
import android.graphics.RectF;
import android.graphics.Xfermode;
import android.util.AttributeSet;
import android.view.MotionEvent;

public class ImageCutView extends GestureImageView {

	private Paint paint_rect = new Paint();
	private final int mRadius = 200;
	private Xfermode cur_xfermode;
	private Rect r;
	private RectF rf;
	private boolean isToCutImage = false;
	private int shdowColor = 0x55000000;

	public ImageCutView(Context context, AttributeSet attrs) {
		super(context, attrs);
		// paint.setColor(Color.BLUE);
		paint_rect.setColor(shdowColor);
		paint_rect.setAntiAlias(true);
		cur_xfermode = new PorterDuffXfermode(PorterDuff.Mode.DST_OUT);
	}

	@SuppressLint("ClickableViewAccessibility")
	@Override
	public boolean onTouchEvent(MotionEvent event) {

		return super.onTouchEvent(event);
	}

	@SuppressLint("DrawAllocation")
	@Override
	protected void onDraw(Canvas canvas) {
		super.onDraw(canvas);

		if (isToCutImage)
			return;

		if (rf == null || rf.isEmpty()) {
			r = new Rect(0, 0, getWidth(), getHeight());
			rf = new RectF(r);
		}
		// ��imageview���滭�뱳���� Բ��
		int sc = canvas.saveLayer(rf, null, Canvas.MATRIX_SAVE_FLAG
				| Canvas.CLIP_SAVE_FLAG | Canvas.HAS_ALPHA_LAYER_SAVE_FLAG
				| Canvas.FULL_COLOR_LAYER_SAVE_FLAG
				| Canvas.CLIP_TO_LAYER_SAVE_FLAG | Canvas.ALL_SAVE_FLAG);
		paint_rect.setColor(shdowColor);
		canvas.drawRect(r, paint_rect);
		paint_rect.setXfermode(cur_xfermode);
		paint_rect.setColor(Color.WHITE);
		canvas.drawCircle(getWidth() / 2, getHeight() / 2, mRadius, paint_rect);
		canvas.restoreToCount(sc);
		paint_rect.setXfermode(null);
	}

	public Bitmap onClip() {
		// ��ȡimageview��bitmap
		// Ϊ�˲����͸���ı���������ˢ����imageview �û�ɾ���λͼ Ȼ���ȡ
		Paint paint = new Paint();
		isToCutImage = true;
		invalidate();
		setDrawingCacheEnabled(true);
		Bitmap bitmap = getDrawingCache().copy(getDrawingCache().getConfig(),
				false);
		setDrawingCacheEnabled(false);
		// ������Ҫ��ȡ��λͼ ��������ҹ��ƶ��ǳ���Ϥ
		Bitmap bitmap2 = Bitmap.createBitmap(2 * mRadius, 2 * mRadius,
				Config.ARGB_8888);
		Canvas canvas = new Canvas(bitmap2);

		// ��ʵqq��ȡ����Ƭ�Ƿ��ε� ����Բ�ε� �����ҪԲ�ε� �������ٴ����м���
//		canvas.drawRoundRect(new RectF(0, 0, 2 * mRadius, 2 * mRadius),
//				mRadius, mRadius, paint);
//		paint.setXfermode(new PorterDuffXfermode(Mode.SRC_IN));
		RectF dst = new RectF(-bitmap.getWidth() / 2 + mRadius, -getHeight()
				/ 2 + mRadius, bitmap.getWidth() - bitmap.getWidth() / 2
				+ mRadius, getHeight() - getHeight() / 2 + mRadius);
		canvas.drawBitmap(bitmap, null, dst, paint);
		isToCutImage = false;
		return bitmap2;
	}

}
