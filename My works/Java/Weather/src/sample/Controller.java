package sample;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.URL;
import java.net.URLConnection;
import java.util.ResourceBundle;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.image.ImageView;
import javafx.scene.text.Text;
import org.json.JSONObject;
import java.util.*;
public class Controller {


    @FXML
    private ResourceBundle resources;

    @FXML
    private URL location;

    @FXML
    private Text temp_pogoda1;

    @FXML
    private Text temp_info;

    @FXML
    private Text temp_min;

    @FXML
    private Text temp_wind;

    @FXML
    private Text temp_pogoda;

    @FXML
    private TextField city;

    @FXML
    private Text temp_feels;

    @FXML
    private Text temp_max;

    @FXML
    private Button getData;

    @FXML
    private Text temp_city;

    @FXML
    void initialize() {
        // При нажатии на кнопку
        getData.setOnAction(event -> {
            // Получаем данные из текстового поля
            String getUserCity = city.getText().trim();
            if(!getUserCity.equals("")) { // Если данные не пустые
                // Получаем данные о погоде с сайта openweathermap
                String output = getUrlContent("http://api.openweathermap.org/data/2.5/weather?q=" + getUserCity + "&appid=ed3475fb9cbce84934f0c6a816d898af&units=metric&lang=ru");

                if (!output.isEmpty()) { // Нет ошибки и такой город есть
                    JSONObject obj = new JSONObject(output);
                    // Обрабатываем JSON и устанавливаем данные в текстовые надписи
                    temp_info.setText("Температура: " + obj.getJSONObject("main").getDouble("temp") + "°");
                    temp_max.setText("Максимум: " + obj.getJSONObject("main").getDouble("temp_max")+ "°");
                    temp_min.setText("Минимум: " + obj.getJSONObject("main").getDouble("temp_min")+ "°");
                    temp_wind.setText("Скорость ветра: " + obj.getJSONObject("wind").getDouble("speed")+ " м/c");
                    temp_city.setText("Город: " + obj.getString("name"));
                    temp_feels.setText("Влажность: " + obj.getJSONObject("main").getDouble("humidity") + "%");
                }
                else {
                    temp_city.setText("Город: Ошибка");

                }
            }
        });
    }

    // Обработка URL адреса и получение данных с него
    private static String getUrlContent(String urlAdress) {
        StringBuffer content = new StringBuffer();

        try {
            URL url = new URL(urlAdress);
            URLConnection urlConn = url.openConnection();

            BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(urlConn.getInputStream()));
            String line;

            while((line = bufferedReader.readLine()) != null) {
                content.append(line + "\n");
            }
            bufferedReader.close();
        } catch(Exception e) {
            System.out.println("Такой город был не найден!");
        }
        return content.toString();
    }

}
