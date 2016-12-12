package in.srain.cube.views.loadmore;

import in.srain.cube.views.ptr.R;
import android.content.Context;
import android.util.AttributeSet;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.RelativeLayout;
import android.widget.TextView;
import fr.castorflex.android.circularprogressbar.CircularProgressBar;

public class LoadMoreDefaultFooterView extends RelativeLayout implements LoadMoreUIHandler {

    private TextView mTextView;
    private CircularProgressBar progressBar;

    public LoadMoreDefaultFooterView(Context context) {
        this(context, null);
    }

    public LoadMoreDefaultFooterView(Context context, AttributeSet attrs) {
        this(context, attrs, 0);
    }

    public LoadMoreDefaultFooterView(Context context, AttributeSet attrs, int defStyle) {
        super(context, attrs, defStyle);
        setupViews();
    }

    private void setupViews() {
        LayoutInflater.from(getContext()).inflate(R.layout.cube_views_load_more_default_footer, this);
        mTextView = (TextView) findViewById(R.id.cube_views_load_more_default_footer_text_view);
        progressBar = (CircularProgressBar) findViewById(R.id.cube_views_load_more_default_footer_progressbar);
    }

    @Override
    public void onLoading(LoadMoreContainer container) {
        setVisibility(VISIBLE);
        progressBar.setVisibility(View.VISIBLE);
        mTextView.setVisibility(View.INVISIBLE);
        mTextView.setText(R.string.cube_views_load_more_loading);
    }

    @Override
    public void onLoadFinish(LoadMoreContainer container, boolean empty, boolean hasMore) {
        if (!hasMore) {
            setVisibility(VISIBLE);
            progressBar.setVisibility(View.GONE);
            mTextView.setVisibility(View.VISIBLE);
            if (empty) {
                mTextView.setText(R.string.cube_views_load_more_loaded_empty);
            } else {
                mTextView.setText(R.string.cube_views_load_more_loaded_no_more);
            }
        } else {
            setVisibility(INVISIBLE);
        }
    }

    @Override
    public void onWaitToLoadMore(LoadMoreContainer container) {
        setVisibility(VISIBLE);
        progressBar.setVisibility(View.INVISIBLE);
        mTextView.setVisibility(View.VISIBLE);
        mTextView.setText(R.string.cube_views_load_more_click_to_load_more);
    }

    @Override
    public void onLoadError(LoadMoreContainer container, int errorCode, String errorMessage) {
    	progressBar.setVisibility(View.INVISIBLE);
        mTextView.setVisibility(View.VISIBLE);
        mTextView.setText(R.string.cube_views_load_more_error);
    }
}
