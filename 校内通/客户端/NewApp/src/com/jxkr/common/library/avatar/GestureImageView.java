package com.jxkr.common.library.avatar;

import android.annotation.SuppressLint;
import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.Matrix;
import android.graphics.PointF;
import android.graphics.RectF;
import android.graphics.drawable.BitmapDrawable;
import android.util.AttributeSet;
import android.util.FloatMath;
import android.view.MotionEvent;
import android.view.View;
import android.widget.ImageView;
/**
 * ��Imageview�������� �ܶ������
 * @author Admin
 *
 */
@SuppressWarnings("deprecation")
public class GestureImageView extends ImageView{
    Matrix matrix = new Matrix();
    Matrix savedMatrix = new Matrix();
    /**λͼ����*/
    private Bitmap bitmap = null;
    /** ��Ļ�ķֱ���*/
    //private DisplayMetrics dm;

    /** ��С���ű���*/
    float minScaleR = 1.0f;
    
    /** ������ű���*/
    static final float MAX_SCALE = 15f;

    /** ��ʼ״̬*/
    static final int NONE = 0;
    /** �϶�*/
    static final int DRAG = 1;
    /** ����*/
    static final int ZOOM = 2;
    
    /** ��ǰģʽ*/
    int mode = NONE;

    /** �洢float���͵�x��yֵ����������µ�����X��Y*/
    PointF prev = new PointF();
    PointF mid = new PointF();
    float dist = 1f;
    
    public GestureImageView(Context context) {
		super(context);
		setupView();
	}
	
	public GestureImageView(Context context, AttributeSet attrs) {
		super(context, attrs);
		setupView();
	}
	
	
	@SuppressLint("ClickableViewAccessibility")
	public void setupView(){
		//��ȡ��Ļ�ֱ���,��Ҫ��ݷֱ�����ʹ��ͼƬ����
		//dm = context.getResources().getDisplayMetrics();
		
		//���MyImageView����ȡbitmap����
		BitmapDrawable bd = (BitmapDrawable)this.getDrawable();
		if(bd != null){
			bitmap = bd.getBitmap();
		}
		
		//����ScaleTypeΪScaleType.MATRIX����һ������Ҫ
		this.setScaleType(ScaleType.MATRIX);
		this.setImageBitmap(bitmap);
		
		//bitmapΪ�վͲ�����center����
		if(bitmap != null){
			center(true, true);
		}
		this.setImageMatrix(matrix);
		this.setOnTouchListener(new OnTouchListener() {
			@Override
			public boolean onTouch(View v, MotionEvent event) {
				 switch (event.getAction() & MotionEvent.ACTION_MASK) {
			        // ���㰴��
			        case MotionEvent.ACTION_DOWN:
			            savedMatrix.set(matrix);
			            prev.set(event.getX(), event.getY());
			            mode = DRAG;
			            break;
			        // ���㰴��
			        case MotionEvent.ACTION_POINTER_DOWN:
			            dist = spacing(event);
			            // �����������������10�����ж�Ϊ���ģʽ
			            if (spacing(event) > 10f) {
			                savedMatrix.set(matrix);
			                midPoint(mid, event);
			                mode = ZOOM;
			            }
			            break;
			        case MotionEvent.ACTION_UP:{
			        	break;
			        }
			        case MotionEvent.ACTION_POINTER_UP:
			            mode = NONE;
			            //savedMatrix.set(matrix);
			            break;
			        case MotionEvent.ACTION_MOVE:
			            if (mode == DRAG) {
			                matrix.set(savedMatrix);
			                matrix.postTranslate(event.getX() - prev.x, event.getY()
			                        - prev.y);
			            } else if (mode == ZOOM) {
			                float newDist = spacing(event);
			                if (newDist > 10f) {
			                    matrix.set(savedMatrix);
			                    float tScale = newDist / dist;
			                    matrix.postScale(tScale, tScale, mid.x, mid.y);
			                }
			            }
			            break;
			        }
				    GestureImageView.this.setImageMatrix(matrix);
//			        CheckView();
			        invalidate();
			        return true;
			}
		});
	}
	
	
    /**
     * �����������
     */
    protected void center(boolean horizontal, boolean vertical) {
        Matrix m = new Matrix();
        m.set(matrix);
        RectF rect = new RectF(0, 0, bitmap.getWidth(), bitmap.getHeight());
        m.mapRect(rect);

        float height = rect.height();
        float width = rect.width();

        float deltaX = 0, deltaY = 0;

        if (vertical) {
            // ͼƬС����Ļ��С���������ʾ��������Ļ���Ϸ������������ƣ��·�������������
            int screenHeight = getHeight();
            if (height < screenHeight) {
                deltaY = (screenHeight - height) / 2 - rect.top;
            } else if (rect.top > 0) {
                deltaY = -rect.top;
            } else if (rect.bottom < screenHeight) {
                deltaY = this.getHeight() - rect.bottom;
            }
        }

        if (horizontal) {
            int screenWidth = getWidth();
            if (width < screenWidth) {
                deltaX = (screenWidth - width) / 2 - rect.left;
            } else if (rect.left > 0) {
                deltaX = -rect.left;
            } else if (rect.right < screenWidth) {
                deltaX = screenWidth - rect.right;
            }
        }
        matrix.postTranslate(deltaX, deltaY);
    }

    
    
    
    /**
     * ����ľ���
     */
    @SuppressWarnings("deprecation")
	private float spacing(MotionEvent event) {
        float x = event.getX(0) - event.getX(1);
        float y = event.getY(0) - event.getY(1);
        return (float) Math.sqrt(x * x + y * y);
    }

    /**
     * ������е�
     */
    private void midPoint(PointF point, MotionEvent event) {
        float x = event.getX(0) + event.getX(1);
        float y = event.getY(0) + event.getY(1);
        point.set(x / 2, y / 2);
    }
}
