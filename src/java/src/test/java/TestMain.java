import com.baomidou.mybatisplus.generator.AutoGenerator;
import com.baomidou.mybatisplus.generator.config.DataSourceConfig;

public class TestMain {
    public static void main(String[] __){
        new AutoGenerator(
                new DataSourceConfig.Builder("","","").build())
                .execute();
    }
}
